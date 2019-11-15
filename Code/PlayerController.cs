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

	private List<Item> items;

	private NPC activeNPC;
	private ItemClone activeItem;
	
	[SerializeField]
	public List<Item> inventory;
	public bool isActive;

	void OnEnable()
	{
		foreach(var item in items)
		{
			item.OnRewardItem += RewardItem;
			item.OnUseItem += UseItem;
		}
	}

	void OnDisable()
	{
		foreach(var item in items)
		{
			item.OnRewardItem -= RewardItem;
			item.OnUseItem -= UseItem;
		}
	}

	void Awake()
	{
		items = new List<Item>();

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

	private void OnMove(InputValue value)
	{
		Debug.Log("On move" + value);
	}

	public void NpcInteraction()
	{
		activeNPC.ActiveChoice();
	}

	public void MakeChoice(CMD choice)
	{
		activeNPC.MakeChoice( choice );
	}

	public void EndConversation()
	{
		activeNPC.EndConversation();
	}

	public void RegisterItemEvents(Item item)
    {
		items.Add(item);

		item.OnRewardItem += RewardItem;
		item.OnUseItem += UseItem;
    }

//Player Interaction Controller TO:DO 
	void OnTriggerEnter(Collider other) 
    {
        //check players inventory
		activeNPC = other.gameObject.GetComponentInParent<NPC>();

		if( activeNPC != null && activeNPC.conversationIndex > -1 )
		{
			activeNPC.CheckInventoryForTriggers(inventory);
		}

		if( activeNPC != null)
		{
			return;
		}

		activeItem = other.gameObject.GetComponentInParent<ItemClone>();

		if(activeItem != null)
		{
			activeItem.Inspect();
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

	private void RewardItem(Item item)
	{
		inventory.Add(item);
	} 

	private void UseItem(Item item)
	{
		switch(item._name)
		{
			default:
				RemoveItemFromInventory(item);
				break;
		}
	}

	private void RemoveItemFromInventory(Item item)
	{
		for(var i = inventory.Count -1; i >=0; i--)
		{
			if( inventory[i]._name == item._name )
			{
				inventory.Remove(item);
			}
		}
	}
}