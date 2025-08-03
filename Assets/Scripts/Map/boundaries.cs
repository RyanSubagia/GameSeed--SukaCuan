using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaries : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            PlayerItem playerItem = other.GetComponent<PlayerItem>();

            other.transform.position = respawnPoint.position;

            if (playerRb != null)
            {
                playerRb.velocity = Vector3.zero;
                playerRb.angularVelocity = Vector3.zero;
            }

            if (playerItem != null)
            {
                playerItem.hasTahuTek = false;
            }

            TahutekManager.instance.ResetTahuTekPickup();
        }
    }
}
