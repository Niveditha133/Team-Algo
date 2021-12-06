using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text Score;

    private int score = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        Score.text = "SCORE :  " + score.ToString();
    }

    // Update is called once per frame
    public void AddScore()
    {
        score += 5;
        Score.text = "SCORE :  " + score.ToString();
    }
}