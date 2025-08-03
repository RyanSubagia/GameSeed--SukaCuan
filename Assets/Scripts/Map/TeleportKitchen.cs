using UnityEngine;

public class TeleportKitchen : MonoBehaviour
{
    public Transform teleportTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            PlayerItem playerItem = other.GetComponent<PlayerItem>();

            other.transform.position = teleportTarget.position;

            if (playerRb != null)
            {
                playerRb.velocity = Vector3.zero;
                playerRb.angularVelocity = Vector3.zero;
            }

            if (playerItem != null)
            {
                playerItem.hasTahuTek = false;
            }

            if (TahutekManager.instance != null)
            {
                TahutekManager.instance.ResetTahuTekPickup();
            }
        }
    }
}
