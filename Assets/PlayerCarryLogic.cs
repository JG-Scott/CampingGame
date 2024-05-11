using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCarryLogic : MonoBehaviour
{

    public float LerpSpeed = 10f;
    private GameObject m_currentObject;

    [SerializeField] Transform m_followTransform;
    public void Attach(GameObject obj, Vector3 offset) {
        transform.localPosition = offset;
        m_currentObject = Instantiate<GameObject>(obj, transform.position, Quaternion.identity);
    }

    public void Detach() {
        if(m_currentObject != null) {
            Destroy(m_currentObject);
            m_currentObject = null;
        }
    }



    private void Update() {
        if(m_currentObject != null) {
            if(GetComponentInParent<CharacterController>().velocity.magnitude > 0) {
              //  m_currentObject.transform.position = transform.position;
                m_currentObject.transform.parent = transform.parent;
                m_currentObject.transform.localPosition = Vector3.Lerp( m_currentObject.transform.localPosition, transform.localPosition, Time.deltaTime * LerpSpeed);
            } else {
                if(m_currentObject.transform.parent != null) m_currentObject.transform.parent = null;
                m_currentObject.transform.position = Vector3.Lerp( m_currentObject.transform.position, transform.position, Time.deltaTime * LerpSpeed);
            }

            m_currentObject.transform.rotation = Quaternion.Slerp(m_currentObject.transform.rotation, transform.rotation, Time.deltaTime * LerpSpeed);
            //m_currentObject.transform.position = Vector3.Lerp(m_currentObject.transform.position, transform.position, Time.deltaTime * LerpSpeed);
        }
    }

    public string CurrentHeldGameObjectTag() {
        return m_currentObject.tag;
    }
}
