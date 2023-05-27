using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockGlobal : MonoBehaviour
{
    //78.716
    public GameObject[] fishPrefab;
    public static int tankSize = 10; //5
    public GameObject goalPrefab;

    static int numFish = 10; //10
    public static GameObject[] allFish = new GameObject[numFish];

    public static Vector3 goalPos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numFish; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tankSize, tankSize),
                                      Random.Range(-tankSize, tankSize),
                                      Random.Range(-tankSize, tankSize));
            allFish[i] = (GameObject)Instantiate(fishPrefab[Random.RandomRange(0,4)], pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0,100000) < 50)
        {
            goalPos = new Vector3(Random.Range(-tankSize, tankSize),
                                  Random.Range(-tankSize, tankSize),
                                  Random.Range(-5, 5));

            goalPrefab.transform.position = goalPos;
        }
    }
}
