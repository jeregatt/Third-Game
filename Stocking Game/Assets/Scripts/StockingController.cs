using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockingController : MonoBehaviour {

	// the character's speed
	float speed = 5f;

	// the character's jump force
	float jumpForce = 500f;

	// this is the character's animator
	Animator anim;

	// this is the character's physics component
	Rigidbody2D playerRB;

	// this is the character's sprite renderer
	SpriteRenderer spriteRenderer;

	// the stocking audio clip
	AudioSource audio;

	// the ground checking object
	Transform groundCheck;

	// is the player touching the ground?
	bool isGrounded = true;

	// the player's default position
	Vector3 defaultPos;


	// when the script is activated, get its components
	void Awake () {

		anim = GetComponent <Animator> ();
		playerRB = GetComponent <Rigidbody2D> ();
		spriteRenderer = GetComponent <SpriteRenderer> ();
		audio = GetComponent <AudioSource> ();

		groundCheck = transform.Find ("groundCheck");
		defaultPos = transform.position;

	}

	// since we're using physics, use the FixedUpdate method
	void FixedUpdate () {

		isGrounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		anim.SetBool ("isGrounded", isGrounded);

		// this tackles the left and right arrow keys
		float h = Input.GetAxisRaw ("Horizontal");

		// jump to the Move method
		Move (h);

		// make the character jump!
		if (Input.GetButtonDown ("Jump") && isGrounded) {
			playerRB.AddForce (Vector2.up * jumpForce);
		}

	}

	// when the player disappears, reset him
	void OnBecameInvisible () {

		transform.position = defaultPos;
		transform.rotation = Quaternion.identity;

	}


	// we can use this to move the character
	void Move (float h) {

		// refer to the current physics movement
		Vector2 movement = playerRB.velocity;
		movement.x = h * speed;

		// make the character move
		playerRB.velocity = movement;

		// check that the player is looking in
		// the direction he's moving
		if ((h < 0f && !spriteRenderer.flipX) || (h > 0f && spriteRenderer.flipX)) {

			spriteRenderer.flipX = !spriteRenderer.flipX;

		}

		// if h is zero, character is still
		// if h is not zero, character is moving
		bool isWalking = (h != 0f);

		// set the boolean value to the condition above
		anim.SetBool ("isWalking", isWalking);

	}


	// collide with the presents and destroy them
	void OnTriggerEnter2D (Collider2D c) {

		if (c.tag == "Present") {
			Destroy (c.gameObject);
		}

	}

	// play the sound
	public void PlayStep () {

		audio.Play ();

	}

}
