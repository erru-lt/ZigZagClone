using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{

    private Button _replayButton;
    private Transform _scoreTableImage;
    private TextMeshProUGUI _scoreText;
    private TextMeshProUGUI _highScoreText;
    private void Awake()
    {
        _replayButton = transform.Find("replayButton").GetComponent<Button>();
        _scoreTableImage = transform.Find("scoreTableImage");
        _scoreText = _scoreTableImage.Find("scoreText").GetComponent<TextMeshProUGUI>();
        _highScoreText = _scoreTableImage.Find("highScoreText").GetComponent<TextMeshProUGUI>();
        

        DeactivateObject();
        ReplayButton();

        SetScoreText();
        SetHighScoreText();
    }

    private void SetHighScoreText()
    {
        GameDataManager.Instance.SetHighScore();
        _highScoreText.SetText("High Score\n" + GameDataManager.Instance.GetHighScore().ToString());
    }

    private void SetScoreText()
    {
        GameDataManager.Instance.SetScore();

        _scoreText.SetText("Score \n" + GameDataManager.Instance.GetScore().ToString());
    }

    private void DeactivateObject()
    {
        gameObject.SetActive(false);
    }

    private void ReplayButton()
    {
        _replayButton.onClick.AddListener(() => GameManager.Instance.ResetGame());
    }

    
}
