// PlayerController.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 10f;
    private Rigidbody rb;
    public float maxSpeed = 20f;

    private PlayerItem playerItem;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerItem = GetComponent<PlayerItem>();
    }

    void FixedUpdate()
    {
        if (GameTimer.instance != null && !GameTimer.instance.timerIsRunning)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            return;
        }

        MoveTowardMouse();
    }

    void MoveTowardMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, transform.position);

        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 targetPoint = ray.GetPoint(distance);
            Vector3 direction = (targetPoint - transform.position).normalized;

            if (rb.velocity.magnitude < maxSpeed)
            {
                Vector3 force = new Vector3(direction.x, 0, direction.z) * moveForce;
                rb.AddForce(force);
            }

            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (GameTimer.instance != null && !GameTimer.instance.timerIsRunning)
        {
            return;
        }

        if (other.CompareTag("TahuTekPickup"))
        {
            if (!playerItem.hasTahuTek)
            {
                playerItem.hasTahuTek = true;
                other.gameObject.SetActive(false);
                AudioManager.instance.PlayPickupSound();
                NotificationManager.instance.ShowNotification("Picked up a Tahu Tek !");

            }
        }
        else if (other.CompareTag("Customer"))
        {
            if (playerItem.hasTahuTek)
            {
                Customer customer = other.GetComponent<Customer>();
                if (customer != null)
                {
                    customer.OnServed();
                    NotificationManager.instance.ShowNotification("Tahu Tek delivered! Return to the kitchen.");
                }
                playerItem.hasTahuTek = false;
            }
        }
    }
}