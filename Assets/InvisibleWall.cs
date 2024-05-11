using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    public string Message;
    private int m_grabbedObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            HUDController.Instance.DisplayMessage(Message);
        }    
    }

    public void ObjectGrabbed() {
        m_grabbedObjects++;
        if(m_grabbedObjects >= 2) {
            GameManager.Instance.ProgressObjective();
            transform.parent.gameObject.SetActive(false);
        }
    }
}
