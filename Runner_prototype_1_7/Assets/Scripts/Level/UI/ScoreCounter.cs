using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    private int _score;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _score = 0;

    }

    public void AddScore()
    {
        _score++;
        _text.text = "Score: " + _score.ToString();

    }
}
