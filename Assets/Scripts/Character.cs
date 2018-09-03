using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float mouseSpeed;
    private Vector3 direction;
	private SpriteRenderer mySpriteRenderer;
	private Animator animator;

	void Start () {
		animator = GetComponentInChildren<Animator>();
		mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}
	
	void Update () {
        getInput();
        Move();
    }

    public void Move()
    {
        transform.Translate(direction*speed*Time.deltaTime);
        AnimateMovement ();
    }

    private void getInput()
    {
        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
			mySpriteRenderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
			mySpriteRenderer.flipX = true;
        }
        if (Input.GetMouseButton(2))
        {
            transform.Rotate(new Vector3(0, -Input.GetAxis("Mouse X") * mouseSpeed, 0));
        }
    }

	public void AnimateMovement()
	{
		animator.SetFloat ("x", direction.x);
		animator.SetFloat ("y", direction.y);
        animator.SetFloat ("z", direction.z);
	}
}
