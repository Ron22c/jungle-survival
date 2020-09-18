using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	public float speed;
	public bool moveright;
    Rigidbody2D myRigidBody;

    void Start() 
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(moveright) {
        	transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(0.07f, 0.07f );
        } else {
        	transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        	transform.localScale = new Vector2(-0.07f, 0.07f );
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        ToggleMoveRight();
    }

    private void ToggleMoveRight() {
        if(moveright) {
            moveright = false;
        } else {
            moveright = true;
        }
    }
}
