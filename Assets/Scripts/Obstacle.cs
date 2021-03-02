using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.CompareTag("ChildCube"))
		{
			collision.gameObject.transform.SetParent(null); // ÇARPAN OBJELER CHİLD OLMAKTAN ÇIKTI
			FindObjectOfType<MovementCube>().stackCubes.Remove(collision.gameObject);
		}
	}
}
