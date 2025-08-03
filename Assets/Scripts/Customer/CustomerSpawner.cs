// CustomerSpawner.cs
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject[] customerPrefabs;
    public Transform[] spawnPoints;
    public float spawnInterval = 10f;

    private List<Transform> availableSpawnPoints = new List<Transform>();

    void Start()
    {
        availableSpawnPoints.AddRange(spawnPoints);
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            if (GameTimer.instance != null && !GameTimer.instance.timerIsRunning)
            {
                yield break;
            }

            if (availableSpawnPoints.Count > 0)
            {
                SpawnCustomer();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnCustomer()
    {
        int spawnIndex = Random.Range(0, availableSpawnPoints.Count);
        Transform spawnPoint = availableSpawnPoints[spawnIndex];

        int prefabIndex = Random.Range(0, customerPrefabs.Length);
        GameObject chosenPrefab = customerPrefabs[prefabIndex];

        GameObject customer = Instantiate(chosenPrefab, spawnPoint.position, Quaternion.identity);

        customer.GetComponent<Customer>().SetSpawnPoint(spawnPoint);

        availableSpawnPoints.RemoveAt(spawnIndex);
    }

    public void FreeSpawnPoint(Transform point)
    {
        if (!availableSpawnPoints.Contains(point))
        {
            availableSpawnPoints.Add(point);
        }
    }
}