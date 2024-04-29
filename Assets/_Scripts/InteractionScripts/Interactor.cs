using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Interactor : MonoBehaviour
{

    public Transform InteractorSource;
    public float InteractionRange = 3;

    Interactable m_currentInteractable;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        if(Input.GetKeyDown(KeyCode.E) && m_currentInteractable != null) 
        {
            m_currentInteractable.Interact();
        }
    }

    void CheckInteraction(){
        RaycastHit hit;
        Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);

        if(Physics.Raycast(ray, out hit, InteractionRange)) 
        {
            if(hit.collider.tag == "Interactable")
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                if(m_currentInteractable && newInteractable != m_currentInteractable){
                    m_currentInteractable.DisableOutline();
                }

                if(newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                } 
                else 
                {
                    DisableCurrentInteractable();
                }

            } 
            else // if hit object is not an interactable
            {
                DisableCurrentInteractable();
            }

        } 
        else // if nothing is within reach. 
        { 
            DisableCurrentInteractable();
        }
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        m_currentInteractable = newInteractable;
        m_currentInteractable.EnableOutline();
        HUDController.Instance.EnableInteractionText(m_currentInteractable.Message);
    }

    void DisableCurrentInteractable() 
    {
        HUDController.Instance.DisableInteractionText();
        if(m_currentInteractable) 
        {
            m_currentInteractable.DisableOutline();
            m_currentInteractable = null;
        }
    }
}
