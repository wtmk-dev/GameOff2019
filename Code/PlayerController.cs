using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 6.0F, gravity = 20.0F;

	[SerializeField]
	private int playerNumber;

	[SerializeField]
	private CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;

	private NPC activeNPC;

	public List<string> inventory;
	public bool isActive;


	void Awake()
	{
		inventory = new List<string>();

		inventory.Add("Lost Wallet");

		isActive = false;
		activeNPC = null;
	}

	void Start(){
		// Store reference to attached component
		controller = GetComponent<CharacterController>();
	}

	void Update() 
	{
		// Character is on ground (built-in functionality of Character Controller)
		if (controller.isGrounded && isActive) 
		{
			// Use input up and down for direction, multiplied by speed
			moveDirection = new Vector3(Input.GetAxis("Horizontal_" + playerNumber), 0, Input.GetAxis("Vertical_" + playerNumber));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
		}

		// Debug.Log(moveDirection);
		// Apply gravity manually.
		moveDirection.y -= gravity * Time.deltaTime;
		// Move Character Controller
		controller.Move(moveDirection * Time.deltaTime);

	}

	public NPC GetActiveNpc()
	{
		return activeNPC;
	}

	private void OnMove(InputValue value)
	{
		Debug.Log("On move" + value);
	}

//Player Interaction Controller TO:DO 
	void OnTriggerEnter(Collider other) 
    {
        //check players inventory
		activeNPC = other.gameObject.GetComponentInParent<NPC>();

		if( activeNPC != null )
		{
			activeNPC.CheckInventoryForTriggers(inventory);
		}
       
    }

	void OnTriggerExit(Collider other) 
    {
        //check players inventory
		activeNPC = other.gameObject.GetComponentInParent<NPC>();

		if( activeNPC != null )
		{
			activeNPC.ExitConversationRange();
		}
       
    }
}