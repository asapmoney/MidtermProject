using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Add this for scene management

public class HealthDrainOnCollision : MonoBehaviour
{
    // Reference to the health slider UI
    public Slider healthSlider;
    
    // The amount of health to drain on collision (now set to 3)
    public float healthDrainAmount = 3f; // Drain 3 health per collision
    
    // Sound to play when collision occurs
    public AudioClip collisionSound;
    private AudioSource audioSource;

    // The name of the defeat scene to load when health reaches 0
    public string defeatSceneName = "DefeatScene"; // Change this to your scene's name

    void Start()
    {
        // Get the AudioSource component (assuming it exists on the same object)
        audioSource = GetComponent<AudioSource>();
        

        // Ensure the slider max value is set to 10 (in case it isn't)
        if (healthSlider.maxValue != 10f)
        {
            healthSlider.maxValue = 10f;
            healthSlider.value = 10f; // Set the initial health to max health
        }

        // Make sure this GameObject has a Collider set as Trigger
        if (!GetComponent<Collider>().isTrigger)
        {
            Debug.LogWarning("Collider on this object is not set to Trigger. Please enable 'Is Trigger' for the Collider.");
        }
    }

    // Called when another collider enters the trigger collider of this object
    void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with this object
        if (other.CompareTag("Player"))
        {
            // Drain health by the specified amount (now 3)
            if (healthSlider != null)
            {
                healthSlider.value -= healthDrainAmount;
                
                // Ensure the health doesn't go below 0
                if (healthSlider.value < 0)
                {
                    healthSlider.value = 0;
                }
            }

        

            // If health reaches 0, load the defeat scene
            if (healthSlider.value == 0)
            {
                LoadDefeatScene();
            }

            // Destroy this prefab after collision
        Destroy(gameObject, audioSource.clip.length); // Destroy after the sound finishes playing
        if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    // Function to load the defeat scene
    void LoadDefeatScene()
    {
        SceneManager.LoadScene(defeatSceneName);
    }
}
