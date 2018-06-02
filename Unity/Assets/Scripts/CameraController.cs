using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform cameraTarget;
	public Transform cameraHolder;
	public float snappiness = 1;

	Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	void Update() {
		transform.LookAt(cameraTarget);
	}

	void FixedUpdate() {
		rb.MovePosition( Vector3.Lerp( transform.position, cameraHolder.position, snappiness ) );
	}
}
