using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]


public class FirstPersonController : MonoBehaviour {

	public float movementSpeed = 2.0f;
	public float mouseSensitivity = 2.0f;

	float verticalRotation = 0f;
	public float upDownRanGe = 60.0f;
	public GameObject camera1;
	CharacterController cc;
	float verticalVelocity = 0f;

	public float jumpSpeed = 7.0f;


	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		cc = GetComponent<CharacterController> ();

	}
	
	// Update is called once per frame

	void Update () {

		float rotateLeftRiht = Input.GetAxis ("MouseX") * mouseSensitivity;
		transform.Rotate (0, rotateLeftRiht, 0);

		verticalRotation -= Input.GetAxis ("MouseY") * mouseSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -upDownRanGe, upDownRanGe);

		camera1.GetComponent<Camera>().transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);

		if ( cc.isGrounded && Input.GetButtonDown ("Jump")) {

			verticalVelocity = jumpSpeed;
		}



		float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
		float backwardSpeed = Input.GetAxis ("Horizontal")* movementSpeed;
		verticalVelocity += Physics.gravity.y * Time.deltaTime;

		Vector3 speed = new Vector3 (backwardSpeed,verticalVelocity,forwardSpeed);

		speed = transform.rotation * speed;


		cc.Move (speed * Time.deltaTime);

	}
}
