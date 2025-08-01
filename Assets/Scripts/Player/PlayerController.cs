using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 10f; // strength of rolling
    private Rigidbody rb;
    public float maxSpeed = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
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

}
