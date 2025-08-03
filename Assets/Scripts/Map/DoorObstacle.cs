using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObstacle : MonoBehaviour
{
    public Vector3 openPos;
    public Vector3 closedPos;
    public float openSpeed = 3f;
    public float closeSpeed = 40f;
    public float interval = 2f;

    private bool isOpen = false;
    private float timer = 0f;

    void Start()
    {
        transform.localPosition = openPos;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            isOpen = !isOpen;
            timer = 0f;
        }

        if (isOpen)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, openPos, openSpeed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, closedPos, closeSpeed * Time.deltaTime);
        }
    }
}
