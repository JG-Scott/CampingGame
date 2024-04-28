using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float MouseSensitivity = 100f;
    public Transform PlayerBody;

    private float m_XRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
    
        m_XRotation -= mouseY;
        m_XRotation = Math.Clamp(m_XRotation, -90f, 90f);

        PlayerBody.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(m_XRotation, 0f, 0f);
    }
}
