using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [Header("Components and Variables")]
    public Transform target;
    public float smoothSpeed;
    public Vector3 offset;

	// Look Rotation
	void LateUpdate()
    {
        offset = new Vector3(5, 6, -9);
        RePosition(offset);


        if (FindObjectOfType<MovementCube>().stackCubes.Count > 4 && FindObjectOfType<MovementCube>().stackCubes.Count <= 7)
		{
            offset = new Vector3(5, 4, -13);
            RePosition(offset);
        }
    }

    public void RePosition(Vector3 offset)
	{
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothPosition;
    }
}
