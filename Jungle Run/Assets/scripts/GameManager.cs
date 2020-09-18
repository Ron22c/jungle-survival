using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Player player;
	public ScoreManager scoremanager;
	public AudioSource backGroundSound;
	public AudioSource deathSound;

	private Vector3 startingPoint;
	private Vector3 groundGenerationStartPoint;
	public GroundGenerator groundGenerator;

	public GameObject largeGround;
	public GameObject mediumGround;

	public GameObject gameOverScreen;
	public GameObject gamestartingSreen;

    void Start()
    {
        startingPoint = player.transform.position;
        groundGenerationStartPoint = groundGenerator.transform.position;
        gamestartingSreen.SetActive(true);
        gameOverScreen.SetActive(false);


        player.gameObject.SetActive(false);
    	scoremanager.isScoreIncreasing = false;
    	backGroundSound.Stop();
    }

    public void Quit() {
    	Application.Quit();
    }

    public void Restart() {
    	GroundDestroyer[] distroyer = FindObjectsOfType<GroundDestroyer>();
    	for(int i=0; i<distroyer.Length;i++) {
    		distroyer[i].gameObject.SetActive(false);
    	}
    	largeGround.SetActive(true);
    	mediumGround.SetActive(true);
    	player.transform.position = startingPoint;
    	groundGenerator.transform.position = groundGenerationStartPoint;
    	gameOverScreen.SetActive(false);
    	player.gameObject.SetActive(true);
    	backGroundSound.Play();
    	scoremanager.score = 0;
    	scoremanager.isScoreIncreasing = true;
    }

    public void GameOver() {
    	player.gameObject.SetActive(false);
    	gameOverScreen.SetActive(true);
    	gamestartingSreen.SetActive(false);
    	scoremanager.isScoreIncreasing = false;
    	backGroundSound.Stop();
    	deathSound.Play();
    }

    public void GameStart() {
    	gamestartingSreen.SetActive(false);
    	Restart();
    }

}
