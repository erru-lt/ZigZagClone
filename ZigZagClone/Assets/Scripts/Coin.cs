using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int _scoreToAdd = 5;
    private void OnTriggerEnter(Collider other)
    {
        Character character = other.gameObject.GetComponent<Character>();

        if(character != null)
        {
            GameDataManager.Instance.AddScore(_scoreToAdd);
            ScoreUI.Instance.UpdateScoreText();
            gameObject.SetActive(false);
        }
    }
}
