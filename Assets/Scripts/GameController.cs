using System;
using TMPro;
using UnityEngine;


public class GameController : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Plate _playerPlate;
    [SerializeField] private Plate _enemyPlate;
    [SerializeField] private TextMeshProUGUI _playerScoreText;
    [SerializeField] private TextMeshProUGUI _enemyScoreText;

    private int _playerScore;
    private int _enemyScore;
    
    public enum PlayerType
    {
        Gamer,
        Enemy
    }

    private void Awake()
    {
        EventsSystem.OnPlayerScored += OnScored;
    }

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        SetPlayerScore(0);
        SetEnemyScore(0);
        StartRound();
    }

    private void StartRound()
    {
        _playerPlate.ResetPosition();
        _enemyPlate.ResetPosition();
        _ball.ResetPosition();
        _ball.AddStartImpulse();
    }

    private void OnScored(PlayerType playerType)
    {
        SetPlayerScore(playerType == 0 ? _playerScore : _enemyScore + 1);
        StartRound();
    }
    
    private void SetPlayerScore(int score)
    {
        _playerScore = score;
        _playerScoreText.SetText(score.ToString());
    }

    private void SetEnemyScore(int score)
    {
        _enemyScore = score;
        _enemyScoreText.SetText(score.ToString());
    }
    
    private void OnDestroy()
    {
        EventsSystem.OnPlayerScored -= OnScored;
    }
}