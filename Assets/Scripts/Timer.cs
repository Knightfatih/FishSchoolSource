using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float currentTime;
    public Text timer;
    public float startingTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.watchFish && !PauseMenu.winBool)
        {
            currentTime -= 1f * Time.deltaTime;
            timer.text = ("Timer: ") + currentTime.ToString("0");

            if(currentTime <= 0)
            {
                currentTime = 0;
                PauseMenu.loseBool = true;
            }
        }
    }
}
