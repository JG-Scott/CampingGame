using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class HUDController : Singleton<HUDController>
{
    [SerializeField] TMP_Text m_interactionText;
    [SerializeField] TMP_Text m_noteText;

    private Coroutine m_noteCoroutine;

    public void EnableInteractionText(String message) {
        m_interactionText.text = message + " (E)";
        m_interactionText.gameObject.SetActive(true);
    }

    public void DisableInteractionText() {
        m_interactionText.text = "";
        m_interactionText.gameObject.SetActive(false);
        
    }


    public void DisplayMessage(string message) {
        if(m_noteCoroutine != null) {
            StopCoroutine(m_noteCoroutine);
        }
        m_noteCoroutine = StartCoroutine(DisplayForTime(3, message));
    }

    public IEnumerator DisplayForTime(float time, string message) {
        // display text
        m_noteText.gameObject.SetActive(true);
        m_noteText.text = message;
        // set boolean to like is displaying
        yield return new WaitForSeconds(time);
        // remove text
        m_noteText.gameObject.SetActive(false);
        // set boolean to is not displaying.
        m_noteCoroutine = null;
    }
}
