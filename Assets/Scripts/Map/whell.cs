using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whell : MonoBehaviour
{
    [SerializeField] int wheelSpeed = 10;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * wheelSpeed * Time.deltaTime);
    }
}
