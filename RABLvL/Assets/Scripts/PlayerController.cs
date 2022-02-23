using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

	// Create public variables for player speed, and for the Text UI game objects
	public float speed;

	private float movementX;
	private float movementY;

	private Rigidbody rb;
	private int count;

	// At the start of the game..
	void Start()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

	}

	void FixedUpdate()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);

		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		
	}

	void OnMove(InputValue value)
	{
		Vector2 v = value.Get<Vector2>();

		movementX = v.x;
		movementY = v.y;
	}

}

