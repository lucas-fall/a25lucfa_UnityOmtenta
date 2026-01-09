using UnityEngine;

public class PatrolBetweenPoints : MonoBehaviour
{
    [Header("Patrol Points")]
    public Transform pointA;
    public Transform pointB;

    [Header("Movement")]
    public float speed = 2f;

    private Transform currentTarget;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentTarget = pointB;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Move toward the current target
        transform.position = Vector2.MoveTowards(
            transform.position,
            currentTarget.position,
            speed * Time.deltaTime
        );

        // Flip sprite based on movement direction (X only)
        if (currentTarget.position.x < transform.position.x)
            spriteRenderer.flipX = true;
        else if (currentTarget.position.x > transform.position.x)
            spriteRenderer.flipX = false;

        // Switch target when close enough
        if (Vector2.Distance(transform.position, currentTarget.position) < 0.05f)
        {
            currentTarget = currentTarget == pointA ? pointB : pointA;
        }
    }
}