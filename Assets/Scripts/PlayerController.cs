using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 7f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    public Transform groundCheckPoint;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	private bool isTouchingGround;
    private Animator playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D> ();
        playerAnimation = GetComponent<Animator> ();

    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle (groundCheckPoint.position,groundCheckRadius,groundLayer);
        movement = Input.GetAxis("Horizontal");
        if(movement > 0f)
		{
			rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2 (1.034049f,1.034049f);
		}
		else if(movement < 0f)
		{
			rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2 (-1.034049f,1.034049f);
		}
        else
		{
			rigidBody.velocity = new Vector2 (0, rigidBody.velocity.y);
		}
        if(Input.GetButtonDown("Jump") && isTouchingGround){

			rigidBody.velocity = new Vector2 (rigidBody.velocity.x, jumpSpeed);
		}
        playerAnimation.SetFloat ("Speed", Mathf.Abs(rigidBody.velocity.x));
		playerAnimation.SetBool ("OnGround", isTouchingGround);
    }
}
