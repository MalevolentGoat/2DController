using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float speed;
    public float mouseSpeed;
    public float gravity;
    public float jumpSpeed;
    private bool isGrounded = true;
    public float GroundDistance = 0.2f;
    public LayerMask Ground;
    private Vector3 velocity;
    private Vector3 direction;
	private SpriteRenderer spriteRenderer;
	private Animator animator;
    private CharacterController controller;
    private Transform groundChecker;

    void Start () {
		animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        groundChecker = transform.GetChild(0);
    }
	
	void Update () {
        getInput();
        Move();
    }

    public void Move()
    {
        AnimateMovement();

        direction = transform.TransformDirection(direction);

        controller.Move(direction * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    private void getInput()
    {
        direction = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.flipX = true;
        }

        velocity.y += gravity * Time.deltaTime;
        isGrounded = Physics.CheckSphere(groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (isGrounded && velocity.y < 0)
            velocity.y = 0f;

        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            velocity.y += Mathf.Sqrt(jumpSpeed * -2f * gravity);
        }

        if (Input.GetMouseButton(2))
        {
            transform.Rotate(0, -Input.GetAxis("Mouse X") * mouseSpeed, 0);
        }
    }

	public void AnimateMovement()
	{
		animator.SetFloat ("x", direction.x);
        animator.SetFloat ("y", velocity.y);
        animator.SetFloat ("z", direction.z);
	}
}
