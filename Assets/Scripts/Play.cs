using UnityEngine;
using UnityEngine.SceneManagement; // This is required to load scenes.

public class SceneTransition : MonoBehaviour
{
    // This function will be called to load the next scene.
    public void LoadNextScene()
    {
        // Get the current scene's build index.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene based on the current scene index.
        // This assumes scenes are in a sequential order in the Build Settings.
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
