using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionScript : MonoBehaviour {

	[SerializeField]
	private float maxSpeed = 5;
	private float jump = 200;

	private bool canJump;
	private bool facingRight;
	private SpriteRenderer spriteRenderer;
	private Animator animator;
	private Rigidbody2D rb;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> (); 
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		facingRight = true;
	}


	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		HandleMovement(horizontal);
		Flip (horizontal);

		if (Input.GetButtonDown ("Jump") && canJump == true) {
			rb.AddForce (transform.up * jump);
			canJump = false;
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "platform") {
			canJump = true;
			transform.up -= col.transform.position - transform.position;
		}
	}

	private void HandleMovement(float horizontal) {
		rb.velocity = new Vector2(horizontal*maxSpeed, rb.velocity.y);

	}

	private void Flip(float horizontal) {
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}
