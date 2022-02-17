using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text currentScore;
    private static GameManager _instance;
    private int _score = 0;
    public static GameManager Instance => _instance;
    private void Awake()
    {
        _instance = this;
    }
    public void CollectItem(int score)
    {
        this._score += score;
        currentScore.text = _score.ToString();
    }
}
