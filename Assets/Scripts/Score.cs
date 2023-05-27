using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Target")
        {
            ScoreText.score += 10;
            Timer.currentTime += 5;
            gameObject.SetActive(false);
        }
    }
}
