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
}
