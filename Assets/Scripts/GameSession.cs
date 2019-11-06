using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    #region "Singleton"
    public static GameSession Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Another GameSession exists. Destroying " + name);
            Destroy(gameObject);
        }
        Instance = this;
    }
    #endregion

    public int MaxLives = 100;

    int _playerLives = 100;
    int _playerScore = 0;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _playerLives = MaxLives;
        _playerScore = 0;
    }

    public void TakePlayerHit()
    {
        _playerLives -= 1;
        if (_playerLives <= 0) GameOver();
    }

    public void GameOver()
    {
        Debug.Log("You ded");
        Initialize();
        SceneManager.LoadScene(0);
    }

    public void GainScore(int score)
    {
        _playerScore += score;
    }

    public int GetLives()
    {
        return _playerLives;
    }

    public int GetScore()
    {
        return _playerScore;
    }
}
