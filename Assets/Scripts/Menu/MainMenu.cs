using UnityEngine;
using UnityEngine.SceneManagement; // This should stay colored now!

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Level1"; 

    public void StartGame()
    {
        // Fixed: We just use SceneManager directly
        SceneManager.LoadScene(levelToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}