using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Characters
{
    //Public
    public float movementSpeed = 20;
    public float maxSpeed = 5;
    

    //private Vector3 startPos;

    //Private
    private Rigidbody rigid;
    private Vector3 movement;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {

        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(Vector3.forward * movementSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(Vector3.back * movementSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(Vector3.right * movementSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(Vector3.left * movementSpeed);
        }
    }
    
}
