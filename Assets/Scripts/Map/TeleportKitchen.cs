using UnityEngine;

public class TeleportKitchen : MonoBehaviour
{
    public Transform teleportTarget; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleportTarget.position;
            Debug.Log("Player teleported to kitchen.");
        }
    }
}
