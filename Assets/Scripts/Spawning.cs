using System.Collections.Generic;
using UnityEngine;

public class TestSubjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _testSubjectPrefab; // The test subject prefab to spawn

    [SerializeField]
    private int _numberOfTestSubjects = 10; // Number of test subjects to spawn

    [SerializeField]
    private List<Vector3> _possibleSpawnLocations = new List<Vector3>(); // List of possible spawn coordinates

    void Start()
    {
        SpawnTestSubjects();
    }

    private void SpawnTestSubjects()
    {
        // Ensure we do not spawn more test subjects than the number of available spawn locations
        int subjectsToSpawn = Mathf.Min(_numberOfTestSubjects, _possibleSpawnLocations.Count);

        // Shuffle the list of possible spawn locations to randomize the positions
        ShuffleList(_possibleSpawnLocations);

        for (int i = 0; i < subjectsToSpawn; i++)
        {
            Vector3 spawnLocation = _possibleSpawnLocations[i];
            GameObject testSubject = Instantiate(_testSubjectPrefab, spawnLocation, Quaternion.identity, transform);

            // Play the animation after the test subject is instantiated
            Animator animator = testSubject.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("Manny 1");  // Replace "Spawn" with the name of your animation trigger or parameter
            }
        }
    }

    // Helper method to shuffle a list (for random placement of test subjects)
    private void ShuffleList<T>(List<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
