
using System.Collections.Generic;
using UnityEngine;

public class CharacterList : MonoBehaviour
{
    public static CharacterList Instance { get; private set; }


    private List<Transform> _characters;

    private int selectedCharacter;
    private void Awake()
    {
        Instance = this;

        _characters = new List<Transform>();

        AddCharactersToList();
    }

    private void Update()
    {
        UpdateActiveCharacter();
    }

    private void AddCharactersToList()
    {       
        foreach (Transform character in transform)
        {
            _characters.Add(character);
        }
    }

    private void UpdateActiveCharacter()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");

        for (int i = 0; i < _characters.Count; i++)
        {
            _characters[i].gameObject.SetActive(i == selectedCharacter);
        }
    }

    public int GetCharactersListCount()
    {
        return _characters.Count;
    }
}
