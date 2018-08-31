using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    [SerializeField]
    private float speed;
    private Vector2 direction;
	private SpriteRenderer mySpriteRenderer;
	private Animator animator;

	void Start () {
		animator = GetComponent<Animator>();
		mySpriteRenderer = GetComponent<SpriteRenderer>();
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
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
			mySpriteRenderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
			mySpriteRenderer.flipX = true;
        }
    }

	public void AnimateMovement()
	{
		animator.SetFloat ("x", direction.x);
		animator.SetFloat ("y", direction.y);
	}
}
