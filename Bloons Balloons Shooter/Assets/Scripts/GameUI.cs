using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUI : MonoBehaviour {

    public Text scoreText;
    public Text gameOverScoreText;
    public Slider healthBar;

    private int health;
    private int score;
    private string gameInfo = "";
    private Rect boxRect = new Rect(10, 10, 300, 50);
    void OnEnable()
    {
        PlayerBehaviour.OnUpdateHealth += HandleonUpdateHealth;
        AddScore.OnSendScore += HandleonSendScore;
    }
    void OnDisable()
    {
        PlayerBehaviour.OnUpdateHealth -= HandleonUpdateHealth;
        AddScore.OnSendScore -= HandleonSendScore;
    }
    void Start()
    {
        UpdateUI();
        scoreText.text = "0";
        gameOverScoreText.text = "0";
        healthBar.value = healthBar.maxValue;
    }
    void HandleonUpdateHealth(int newHealth)
    {
        health = newHealth;
        UpdateUI();
        healthBar.value = health;
        //print(health / 100);
    }
    void HandleonSendScore(int theScore)
    {
        score += theScore;
        UpdateUI();
        scoreText.text = score.ToString();
        gameOverScoreText.text = score.ToString();
    }
    void UpdateUI()
    {
        gameInfo = "Score: " + score.ToString() + "\nHealth: " + health.ToString();
    }
    void OnGUI()
    {
        //GUI.Box(boxRect, gameInfo);
    }
}