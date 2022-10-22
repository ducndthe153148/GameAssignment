using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public ScoreManagement scoreManagement;
    void Start()
    {
        // Load data from json
        scoreManagement.AddScore(new Score("Long", 25));
        scoreManagement.AddScore(new Score("Duc", 50));
        scoreManagement.AddScore(new Score("Kien", 40));
        scoreManagement.AddScore(new Score("Hung", 100));

        var scores = scoreManagement.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.name.text = scores[i].name;
            row.score.text = scores[i].score.ToString();
            Debug.Log("Da co: " + row);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
