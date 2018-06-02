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
		Vector3 input = Vector3.forward * Input.GetAxis( "Vertical" ) + Vector3.right * Input.GetAxis( "Horizontal" );
		anim.SetFloat( "x input", Input.GetAxis( "Horizontal" ) );
		anim.SetFloat( "z input", Input.GetAxis( "Vertical" ) );
		rb.velocity = input * speed;
	}
}
