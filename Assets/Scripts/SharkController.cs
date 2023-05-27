using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    public float speedChangeAmount;
    public float maxForwardSpeed;
    public float maxBackwardSpeed;
    public float minSpeed;
    public float turnSpeed;
    public float riseSpeed;
    public float stabilizationSmoothing;

    private Rigidbody rb;
    private float curSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!PauseMenu.watchFish && !PauseMenu.winBool && !PauseMenu.loseBool)
        {
            Move();
            Turn();
            Rise();
            Stabilise();
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            curSpeed += speedChangeAmount * (ScoreText.score + 1);
            Debug.Log(curSpeed);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            curSpeed -= speedChangeAmount * (ScoreText.score + 1);

        }
        else if (Mathf.Abs(curSpeed) <= minSpeed)
        {
            curSpeed = 0;
        }
        curSpeed = Mathf.Clamp(curSpeed, -maxBackwardSpeed, maxForwardSpeed);
        rb.AddForce(transform.forward * curSpeed);
    }

    private void Turn()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(transform.up * turnSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(transform.up * -turnSpeed);
        }
    }

    private void Rise()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(transform.up * riseSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            rb.AddForce(transform.up * -riseSpeed);
        }
    }

    private void Stabilise()
    {
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, Quaternion.Euler(new Vector3(0, rb.rotation.eulerAngles.y, 0)), stabilizationSmoothing));
    }
}
