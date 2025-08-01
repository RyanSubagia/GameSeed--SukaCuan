using UnityEngine;
using System.Collections.Generic;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject[] customerPrefabs;
    public Transform[] spawnPoints;
    public float spawnInterval = 10f;

    private float timer = 0f;
    private List<Transform> availableSpawnPoints = new List<Transform>();

    void Start()
    {
        availableSpawnPoints.AddRange(spawnPoints);
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f && availableSpawnPoints.Count > 0)
        {
            SpawnCustomer();
            timer = spawnInterval;
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
