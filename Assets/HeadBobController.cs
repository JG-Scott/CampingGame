using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobController : MonoBehaviour
{
    [SerializeField] private bool m_enable = true;



    // The amplitude and frequency of the head bobbing.
    [SerializeField, Range(0,0.1f)] private float m_amplitude = 0.015f;
    [SerializeField, Range(0,30f)] private float m_frequency = 10f;



    // Transforms for both the camera and the camera holder
    [SerializeField] private Transform m_camera = null;
    [SerializeField] private Transform m_cameraHolder = null;


    // The minimum speed which the head bob starts
    private float m_toggleSpeed = 3.0f;

    // Start position for the camera, goes back to this position when movement stops.
    private Vector3 m_startPos;

    // Refrence to player movement controller
    private CharacterController m_controller;




    private void Awake() {
        m_controller = GetComponent<CharacterController>();
        m_startPos = m_camera.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(!m_enable) return;
        CheckMotion();
        m_camera.LookAt(FocusTarget());

        
    }


    //Resets the position of the camera, checks to see if the player is moving/on ground, if so plays a single head bob
    private void CheckMotion() {   
        float speed = new Vector3(m_controller.velocity.x, 0, m_controller.velocity.z).magnitude;
        ResetPosition();

        if(!m_controller.isGrounded) return;

        if(speed < m_toggleSpeed) {
           PlayMotion(IdleHeadBobMotion());
        } else {
            PlayMotion(FootStepMotion());
        }
    }

    // Resets camera position back to start position
    private void ResetPosition() {
        if(m_camera.localPosition == m_startPos) return;
        m_camera.localPosition = Vector3.Lerp(m_camera.localPosition, m_startPos, 8*Time.deltaTime);
    }

    // Plays the head bob motion, adds it to the camera local position.
    private void PlayMotion(Vector3 motion){
        m_camera.localPosition += motion; 
    }

    // Generates the footstep motion using a sin function for y Axis and Cos function for x axis.
    private Vector3 FootStepMotion() {
        Vector3 pos = Vector3.zero;
        pos.y = Mathf.Sin(Time.time * m_frequency) * m_amplitude;
        pos.x = Mathf.Cos(Time.time * m_frequency/2) * m_amplitude * 2;
        return pos;
    }

    private Vector3 IdleHeadBobMotion() {
        Vector3 pos = Vector3.zero;
        pos.y = Mathf.Sin(Time.time * m_frequency/7) * (m_amplitude/3);
        return pos;
    }


    // Generates a focust target for the camera that is 15 units ahead, makes sure that the camer is always facing forward while moving.
    private Vector3 FocusTarget() {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + m_cameraHolder.localPosition.y, transform.position.z);
        pos+= m_cameraHolder.forward * 15f;
        return pos;
    }
}
