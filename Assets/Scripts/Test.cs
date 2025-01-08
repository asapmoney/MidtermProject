using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSubject : MonoBehaviour
{    public int points = 1; // Points to add when collected

    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided with this test subject has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Play the collection sound when the player touches this object
             GameManager gameManager = FindObjectOfType<GameManager>(); // Find the GameManager
            if (gameManager != null)
            {
                gameManager.AddScore(points); // Add points to the score
            }


            // Destroy this test subject after playing the sound (like collecting the object)
            Destroy(gameObject, audioSource.clip.length); // Destroy after the sound finishes playing
        if (audioSource != null)
            {
                audioSource.Play();
            }}
    }
}
