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
        SetPlayerScore(0, _playerScoreText);
        SetPlayerScore(0, _enemyScoreText);
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
        SetPlayerScore(playerType == PlayerType.Gamer ? ++_playerScore : ++_enemyScore, playerType == PlayerType.Gamer ? _playerScoreText : _enemyScoreText);
        StartRound();
    }
    
    private void SetPlayerScore(int score, TextMeshProUGUI playerScoreText)
    {
        playerScoreText.SetText(score.ToString());
    }
    
    private void OnDestroy()
    {
        EventsSystem.OnPlayerScored -= OnScored;
    }
}