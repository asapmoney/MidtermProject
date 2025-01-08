using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryDefeatTrigger : MonoBehaviour
{
    // Tags that the player and AI will use
    public string playerTag = "Player";
    public string aiTag = "AI";

    // The victory and defeat scene names
    public string victoryScene = "VictoryScene";
    public string defeatScene = "DefeatScene";

    // Called when another collider enters this object’s trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object is tagged as the player
        if (other.CompareTag(playerTag))
        {
            // Load the victory scene
            SceneManager.LoadScene(victoryScene);
        }
        // Check if the object is tagged as the AI
        else if (other.CompareTag(aiTag))
        {
            // Load the defeat scene
            SceneManager.LoadScene(defeatScene);
        }
    }
}
