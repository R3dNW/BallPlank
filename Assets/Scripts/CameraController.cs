using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform sphereTransform;

    [Range(0, 1)]
    public float cameraSpeed;

    public float cameraZPos;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        Vector3 newPosition = Vector3.Lerp(this.transform.position, this.sphereTransform.position, cameraSpeed);

        newPosition.z = this.cameraZPos;

        this.transform.position = newPosition;
	}
}
