using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    float rotation;
    [SerializeField] float rotationPower = 12f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 18f;

    SurfaceEffector2D surfaceEffector;

    Rigidbody2D rb;

    bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rotation = Input.GetAxisRaw("Horizontal") * -rotationPower;
        RespondBoost();
    }

    void RespondBoost()
    {
        if (Input.GetKey("space"))
        {
            Debug.Log("Speed");
            surfaceEffector.speed = boostSpeed;
        }
        else
        {
            surfaceEffector.speed = baseSpeed;
        }

    }

    void FixedUpdate()
    {
        if (canMove)
        {
            rb.AddTorque(rotation);
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }
}
