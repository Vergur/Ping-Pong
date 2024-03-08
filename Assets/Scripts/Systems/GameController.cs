using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Plate _playerPlate;
    [SerializeField] private Plate _enemyPlate;
    [SerializeField] private TextMeshProUGUI _playerScoreText;
    [SerializeField] private TextMeshProUGUI _enemyScoreText;
    [SerializeField] private TextMeshProUGUI _bestScoreText; 
    [SerializeField] private TextMeshProUGUI _currentScoreText; 

    private int _playerScore;
    private int _enemyScore;
    private int _currentScoreStreak;
    private int _bestScore; 
    
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
        GetBestScore();
    }

    public void RestartGame()
    {
        _ball.ResetBallSpeed();
        StartGame();
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
        if (playerType == PlayerType.Enemy)
        {
            SetPlayerScore(++_playerScore);
            _ball.IncreaseBallSpeed(0.5f);
            _currentScoreText.SetText($"Scorestreak:{++_currentScoreStreak}");
            if (_currentScoreStreak > _bestScore) SaveBestScore(_currentScoreStreak);
        }
        else
        {
            SetEnemyScore(++_enemyScore);
            _ball.ResetBallSpeed();
        }

        StartRound();
    }
    
    private void GetBestScore()
    {
        _bestScore = PlayerPrefs.GetInt("BestScore", 0);
        _bestScoreText.SetText($"Best score: {_bestScore.ToString()}");
        _currentScoreText.SetText($"Scorestreak:{0}");
    }

    private void SaveBestScore(int score)
    {
        _bestScore = score;
        PlayerPrefs.SetInt("BestScore", _bestScore); 
        _bestScoreText.SetText($"Best score: {_bestScore.ToString()}");
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
        _currentScoreStreak = 0;
        _currentScoreText.SetText($"Scorestreak:{_currentScoreStreak}");
    }

    private void OnDestroy()
    {
        EventsSystem.OnPlayerScored -= OnScored;
    }
}