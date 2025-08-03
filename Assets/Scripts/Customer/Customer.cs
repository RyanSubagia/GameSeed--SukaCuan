using System.Collections;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public float angryTime = 30f;
    private float timer;
    private bool isAngry = false;

    private Transform mySpawnPoint;
    public int scoreValue = 10;
    void Start()
    {
        timer = angryTime;
        StartCoroutine(SpawnBounce());

    }
    IEnumerator SpawnBounce()
    {
        Vector3 originalScale = transform.localScale;
        transform.localScale = Vector3.zero;

        float duration = 0.3f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            float scale = Mathf.SmoothStep(0f, 1.2f, t);
            transform.localScale = originalScale * scale;
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0f;
        while (elapsed < 0.1f)
        {
            float t = elapsed / 0.1f;
            float scale = Mathf.Lerp(1.2f, 1f, t);
            transform.localScale = originalScale * scale;
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale;
    }
    public void SetSpawnPoint(Transform point)
    {
        mySpawnPoint = point;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (!isAngry && timer <= 0f)
        {
            GetAngry();
        }
    }

    void GetAngry()
    {
        isAngry = true;
        Debug.Log("Customer got angry and left!");

        FindObjectOfType<CustomerSpawner>().FreeSpawnPoint(mySpawnPoint);

        Destroy(gameObject);
    }

    public void OnServed()
    {
        ScoreManager.instance.AddScore(scoreValue);
        FindObjectOfType<CustomerSpawner>().FreeSpawnPoint(mySpawnPoint);
        Destroy(gameObject);
    }
}
