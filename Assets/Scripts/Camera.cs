using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float movSmoothing;
    public float rotSmoothing;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, movSmoothing);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotSmoothing);
    }
}
