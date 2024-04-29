using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class HUDController : Singleton<HUDController>
{
    [SerializeField] TMP_Text m_interactionText;

    public void EnableInteractionText(String message) {
        m_interactionText.text = message + " (E)";
        m_interactionText.gameObject.SetActive(true);
    }

    public void DisableInteractionText() {
        m_interactionText.text = "";
        m_interactionText.gameObject.SetActive(false);
    }
}
