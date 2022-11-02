using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public Text highScoreText;
    int highScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highScore = CountScore.scoreValue;
        if (PlayerPrefs.GetInt("score") <= highScore)
            PlayerPrefs.SetInt("score", highScore);
        highScoreText.text = "Highest Score: " +PlayerPrefs.GetInt("score").ToString();
    }
}
