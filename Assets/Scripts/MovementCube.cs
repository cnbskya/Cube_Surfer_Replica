using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCube : MonoBehaviour
{
    Rigidbody rb;
    public float forwardSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	private void FixedUpdate()
	{
        rb.velocity = Vector3.forward * forwardSpeed * Time.deltaTime;
	}
}
