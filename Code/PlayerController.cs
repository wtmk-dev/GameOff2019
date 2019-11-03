using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 6.0F, gravity = 20.0F;

	[SerializeField]
	private int playerNumber;

	[SerializeField]
	private CharacterController controller;

	private Vector3 moveDirection = Vector3.zero;

	void Start(){
		// Store reference to attached component
		controller = GetComponent<CharacterController>();
	}

	void Update() 
	{
		// Character is on ground (built-in functionality of Character Controller)
		if (controller.isGrounded) 
		{
			// Use input up and down for direction, multiplied by speed
			moveDirection = new Vector3(Input.GetAxis("Horizontal_" + playerNumber), 0, Input.GetAxis("Vertical_" + playerNumber));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
		}

		Debug.Log(moveDirection);
		// Apply gravity manually.
		moveDirection.y -= gravity * Time.deltaTime;
		// Move Character Controller
		controller.Move(moveDirection * Time.deltaTime);

	}

	private void OnMove(InputValue value)
	{
		Debug.Log("On move" + value);
	}
}