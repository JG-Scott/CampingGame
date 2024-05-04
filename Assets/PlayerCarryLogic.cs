using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCarryLogic : MonoBehaviour
{

    public float LerpSpeed = 10f;
    private GameObject m_currentObject;
    [SerializeField] Transform m_followTransform;
    public void Attach(GameObject obj) {
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
            //m_currentObject.transform.position = transform.position;
                m_currentObject.transform.position = Vector3.Lerp( m_currentObject.transform.position, transform.position, Time.deltaTime * LerpSpeed);

            m_currentObject.transform.rotation = Quaternion.Slerp(m_currentObject.transform.rotation, transform.rotation, Time.deltaTime * LerpSpeed);
            //m_currentObject.transform.position = Vector3.Lerp(m_currentObject.transform.position, transform.position, Time.deltaTime * LerpSpeed);
        }
    }
}
