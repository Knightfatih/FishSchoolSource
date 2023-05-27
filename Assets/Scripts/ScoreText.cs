using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public GameObject scoreText;
    public static int score;
    public float maxScore = 100;

    public void Update()
    {
        scoreText.GetComponent<Text>().text = "Score: " + score;

        if(score >= maxScore)
        {
            PauseMenu.winBool = true;
        }
    }
}
