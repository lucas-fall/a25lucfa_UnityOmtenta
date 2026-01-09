using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Drag your Player object here
    public Vector3 offset = new Vector3(0, 0, -10); // Keeps the camera at a distance
    public float smoothSpeed = 0.125f; // Higher = faster camera movement

    // LateUpdate runs after the player has moved for the frame
    void LateUpdate()
    {
        if (player != null)
        {
            // Create the target position based on player + offset
            Vector3 desiredPosition = player.position + offset;
            
            // Smoothly move from current position to desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            
            // Apply the position
            transform.position = smoothedPosition;
        }
    }
}