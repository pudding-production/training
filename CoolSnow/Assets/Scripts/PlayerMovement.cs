using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] float movement;
   [SerializeField] float movementSpeed = 0.1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal") * movementSpeed;
    }

    private void FixedUpdate()
    {
        transform.Translate(movement, 0, 0);
    }
}
