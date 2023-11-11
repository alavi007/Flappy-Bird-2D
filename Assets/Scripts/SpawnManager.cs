using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] pipePrefab;
    
    // Keep track of active pipes.
    private List<GameObject> activePipes = new List<GameObject>(); 

    private float posSpawnRangeY = 3.5f;
    private float negSpawnRangeY = -1f;

    private float startDelay = 1f;
    private float spawnInterval = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomPipe", startDelay, spawnInterval);
    }

    public void ClearPipes()
    {
        foreach (GameObject pipe in activePipes)
        {
            Destroy(pipe);
        }
        activePipes.Clear(); // Clear the list of active pipes.
    }

    void SpawnRandomPipe()
    {
        float randomY = Random.Range(negSpawnRangeY, posSpawnRangeY);
        
        Vector2 spawnPos = new Vector2(11f, randomY);

        int pipeIndex = Random.Range(0, pipePrefab.Length);
        
        GameObject newPipe = Instantiate(pipePrefab[pipeIndex], spawnPos, pipePrefab[pipeIndex].transform.rotation);
        activePipes.Add(newPipe); // Add the new pipe to the list of active pipes.
    }
}
