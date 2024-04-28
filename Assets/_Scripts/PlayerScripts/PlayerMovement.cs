using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController Controller;
    public Transform GroundCheck;

    public float GroundDistance;

    public LayerMask GroundMask;


    public float Speed = 12;
    public float GravityScale = -29.81f;


    Vector3 m_Velocity;
    bool m_isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if(m_isGrounded && m_Velocity.y < 0) {
            m_Velocity.y = -2f;
        }
        
        
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z).normalized * Speed * Time.deltaTime;

        m_Velocity.y += GravityScale * Time.deltaTime * Time.deltaTime;

        move += m_Velocity;
    
        Controller.Move(move);

    }
}
