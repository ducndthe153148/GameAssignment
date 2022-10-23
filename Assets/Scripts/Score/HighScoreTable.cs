using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);
        float templateHeight = 50f;
        for(int i = 0; i < 10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            //int rank = i + 1;
            //string rankString;
            //switch (rank)
            //{
            //    case 1: rankString = "1ST"; break;
            //    case 2: rankString = "2ND"; break;
            //    case 3: rankString = "3RD"; break;
            //    default: rankString = rank + "TH"; break;
            //}
            //entryTransform.Find("posText").GetComponent<TextMeshPro>().text = rankString;
            //int score = Random.Range(0, 1000);
            //entryTransform.Find("scoreText").GetComponent<TextMeshPro>().text = score.ToString();

            //string name = "Duc";
            //entryTransform.Find("nameText").GetComponent<TextMeshPro>().text = name;
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
