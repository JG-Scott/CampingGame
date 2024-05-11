using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpTentObjective : Objective
{

    override public void HandleNextComponent() {
        switch(m_currentComponentIndex)
        {
            case 0:
                components[m_currentComponentIndex].ObjectiveObjects[0].GetComponent<BoxCollider>().enabled = true;
            break;
            case 1:
                components[m_currentComponentIndex].ObjectiveObjects[0].SetActive(true); 
            break;
        }
    }

}
