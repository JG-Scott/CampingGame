using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{

    Outline m_outline;

    public string Message;

    public UnityEvent OnInteraction;

    // Start is called before the first frame update
    void Start()
    {
        m_outline = GetComponent<Outline>();
        m_outline.enabled = false;
    }

    public void Interact() {
       OnInteraction.Invoke(); 
    }
    public void DisableOutline(){
        m_outline.enabled = false;
    }

    public void EnableOutline(){
        m_outline.enabled = true;
    }

}
