
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance { get; private set; }

    public GameData gameData = new GameData();

    private void Awake()
    {
        Instance = this;
    }

    public int GetScore()
    {
        return gameData.Score;
    }

    public int GetHighScore()
    {
        gameData.HighScore = PlayerPrefs.GetInt(gameData.HighScoreKey);
        return gameData.HighScore;
    }

    public void AddScore(int scoreToAdd)
    {
        gameData.Score += scoreToAdd;
        SetScore();
    }

    public void SetScore()
    {
        PlayerPrefs.SetInt(gameData.ScoreKey, gameData.Score);
    }

    public void SetHighScore()
    {
        if (GetScore() > GetHighScore())
        {
            PlayerPrefs.SetInt(gameData.HighScoreKey, GetScore());
        }
    }

    [System.Serializable]
    public class GameData
    {
        private string _scoreKey = "scoreKey";
        private string _highScoreKey = "highScoreKey";

        private int _score;
        private int _highScore;

        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
            }
        }
        public string ScoreKey
        {
            get
            {
                return _scoreKey;
            }
            private set
            {

            }
        }

        public int HighScore
        {
            get
            {
                return _highScore;
            }
            set
            {
                _highScore = value;
            }
        }
        public string HighScoreKey
        {
            get
            {
                return _highScoreKey;
            }
            private set
            {

            }
        }

    }

}


