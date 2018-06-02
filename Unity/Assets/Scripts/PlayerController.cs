using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public static PlayerController instance;

	public GameObject cameraTarget;
	public float turnSpeed;

	Animator anim;
	Rigidbody rb;

	public Transform cam;

	public float speed;

	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if(instance == null)
			instance = this;
		else {
			Debug.LogError( "2 PlayerControllers active" );
			Destroy( gameObject );
		}
		anim = GetComponentInChildren<Animator>();
		rb = GetComponent<Rigidbody>();
	}

	void Update() {
		transform.RotateAround( transform.position, transform.up, Time.deltaTime * turnSpeed * Input.GetAxis( "Mouse X" ) );
	}

	void FixedUpdate() {
		Vector3 input = transform.forward * Input.GetAxis( "Vertical" ) + transform.right * Input.GetAxis( "Horizontal" );
		anim.SetFloat( "x input", Input.GetAxis( "Horizontal" ) );
		anim.SetFloat( "z input", Input.GetAxis( "Vertical" ) );
		rb.velocity = input * speed;
	}
}
