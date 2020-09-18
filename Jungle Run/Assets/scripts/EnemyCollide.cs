using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollide : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
     	gameManager = FindObjectOfType<GameManager>();   
    }

	void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.name == "Player") {
            Debug.Log("DEAD");
            gameManager.GameOver();
        }
    }
}
