using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private int speed = 10;
    private Vector2 speedVec;

    private void Update()
    {
        speedVec = Vector2.zero;
        if (Input.GetKey(KeyCode.D))
        {
            speedVec.x += speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            speedVec.x -= speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            speedVec.y += speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            speedVec.y -= speed;
        }
        GetComponent<Rigidbody2D>().velocity = speedVec;
    }
}
