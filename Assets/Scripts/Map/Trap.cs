using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float rotSpeed = 500f;
    public float rotationAngle = 180f;
    public float startDelay = 0.5f;
    public float intervalBetweenTurns = 1f;
    public float forcePower = 500f;

    private bool isActive = false;
    private Quaternion startRotation;
    private Rigidbody playerRb;
    private Vector3 hitDirection;

    void Start()
    {
        startRotation = transform.rotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isActive)
        {
            playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                hitDirection = collision.contacts[0].normal * -1;
            }

            StartCoroutine(RotateTrap());
        }
    }

    IEnumerator RotateTrap()
    {
        isActive = true;

        yield return new WaitForSeconds(startDelay);

        float rotated = 0f;
        bool forceApplied = false;

        while (rotated < rotationAngle)
        {
            float step = rotSpeed * Time.deltaTime;
            transform.Rotate(0, step, 0);
            rotated += step;

            if (!forceApplied && playerRb != null)
            {
                playerRb.AddForce(hitDirection * forcePower, ForceMode.Impulse);
                forceApplied = true;
            }

            yield return null;
        }

        transform.rotation = startRotation;

        yield return new WaitForSeconds(intervalBetweenTurns);
        isActive = false;
    }
}
