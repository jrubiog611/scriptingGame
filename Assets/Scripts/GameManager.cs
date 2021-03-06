﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public bool isWin;
    public static GameManager Instance { get => instance; }

    [Space]
    [SerializeField]
    private Transform player;

    [Space]
    [SerializeField]
    private List<GameObject> enemies;

    public GameObject winPanel;

    public List<GameObject> Enemies { get => enemies; }
    public Text scoreText;


    private int score;
    public int Score { get => score; }

    public Transform Player { get => player; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            isWin = false;
        }
        else
            Destroy(gameObject);
    }
    public void CheckWinCondition()
    {
        if (enemies.Count == 0)
        {
            // Then you win
            winPanel.SetActive(true);
            isWin = true;
        }
    }
    public void SetScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + (score += points).ToString();
        Debug.Log(score);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }
}
