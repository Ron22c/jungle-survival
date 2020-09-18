using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed;
	public float jump;
	public LayerMask ground;
	private Collider2D playerCollider;
	private Rigidbody2D rigidBody;
    private Animator animator;
    public Transform maxHeightPoint;

    public LayerMask deathGround;

    public float milestone;
    private float milestoneCount;
    public float speedMultiplier;

    public AudioSource deathSound;
    public AudioSource jumpSound;

    public GameManager gameManager;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        milestoneCount = milestone;
    }

    void Update()
    {
        bool isDead = Physics2D.IsTouchingLayers(playerCollider, deathGround);

        if(isDead) {
            GameOver();
        }
        
        if(transform.position.x > milestoneCount) {
            milestoneCount += milestone;
            speed = speed * speedMultiplier;
            milestone += milestone * speedMultiplier;
            Debug.Log("M " + milestone + " MC " + milestoneCount + " MS " + speed);
        }

        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
        bool grounded = Physics2D.IsTouchingLayers(playerCollider, ground);
        
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
        	if(grounded || transform.position.y < maxHeightPoint.position.y) {
                jumpSound.Play();
        		rigidBody.velocity = new Vector2(rigidBody.velocity.x, jump);
        	}
        }
        animator.SetBool("Grounded", grounded);
    }

    void GameOver() {
        gameManager.GameOver();
    }
}
