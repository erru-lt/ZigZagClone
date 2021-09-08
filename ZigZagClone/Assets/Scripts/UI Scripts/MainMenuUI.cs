using UnityEngine.UI;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{

    private Button _tapToPlayButton;
    private Button _nextSelectButton;
    private Button _prevSelectButton;

    private int _selectedCharacter = 0;
    private void Awake()
    {
        _tapToPlayButton = transform.Find("tapToPlayButton").GetComponent<Button>();
        _nextSelectButton = transform.Find("nextSelectButton").GetComponent<Button>();
        _prevSelectButton = transform.Find("prevSelectButton").GetComponent<Button>();

        TapToPlayButton();
        NextSelectButton();
        PrevSelectButton();

        PlayerPrefs.SetInt("selectedCharacter", _selectedCharacter);
    }


    private void TapToPlayButton()
    {
        _tapToPlayButton.onClick.AddListener(() => GameManager.Instance.StartGame());
    }

    private void NextSelectButton()
    {
        _nextSelectButton.onClick.AddListener(() => SelectNextCharacter());
    }

    private void PrevSelectButton()
    {
        _prevSelectButton.onClick.AddListener(() => SelectPreviousCharacter());
    }

    private void SelectNextCharacter()
    {
        _selectedCharacter++;
        if(_selectedCharacter > CharacterList.Instance.GetCharactersListCount() - 1)
        {
            _selectedCharacter = 0;
        }

        PlayerPrefs.SetInt("selectedCharacter", _selectedCharacter);
    }

    private void SelectPreviousCharacter()
    {
        if(_selectedCharacter == 0)
        {
            _selectedCharacter = CharacterList.Instance.GetCharactersListCount() - 1;
        }
        else
        {
            _selectedCharacter--;
        }

        PlayerPrefs.SetInt("selectedCharacter", _selectedCharacter);
    }
}
