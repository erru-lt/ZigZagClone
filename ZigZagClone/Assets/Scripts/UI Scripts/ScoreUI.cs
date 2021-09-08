using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{

    public static ScoreUI Instance { get; private set; }


    private TMP_Text _scoreText;

    private void Awake()
    {
        Instance = this;

        _scoreText = transform.Find("scoreText").GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScoreText()
    {
        _scoreText.SetText(GameDataManager.Instance.GetScore().ToString());
    }

}
