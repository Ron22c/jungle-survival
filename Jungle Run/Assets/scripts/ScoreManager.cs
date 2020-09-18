using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public float pointsPerSecond;

	public Text scoreLabel;
	public Text highScoreLabel;

	public float score;
	private float highScore;

	public bool isScoreIncreasing;

    void Start()
    {
    	isScoreIncreasing = false;
        if(PlayerPrefs.HasKey("highScore")) {
        	highScore = PlayerPrefs.GetFloat("highScore");
        }
    }

    void Update()
    {
    	if(isScoreIncreasing) {
        	score += pointsPerSecond * Time.deltaTime;
    	}
        if(score>highScore) {
        	highScore = score;
        	PlayerPrefs.SetFloat("highScore", highScore);
        }

        scoreLabel.text = Mathf.Round(score).ToString();
        highScoreLabel.text = Mathf.Round(highScore).ToString();
    }
}
