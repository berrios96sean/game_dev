using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Will need to add more functionality for any use case where 
    // scene control will be needed. 
    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        // Should create a waiting state scene, maybe display level stats 
        // create some sort of transitions between levels 
    }

}
