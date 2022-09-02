using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl2D : MonoBehaviour
{
    [SerializeField] float moveInput;
    [SerializeField] float moveSpeed;
    Rigidbody2D myRB;

    void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();    
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move_Jump();
    }
    void Move_Jump()
    {
        moveInput = Input.GetAxis("Horizontal");
        myRB.velocity = new Vector2(moveInput * moveSpeed, myRB.velocity.y);
    }
}
