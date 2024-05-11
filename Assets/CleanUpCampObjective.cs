using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpCampObjective : Objective
{

    private int m_trashCollected = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    override public void HandleNextComponent() {
        switch(m_currentComponentIndex)
        {
            case 0:
            break;
            case 1:
                components[m_currentComponentIndex].ObjectiveObjects[0].SetActive(true); 
            break;
        }
    }
    public override void SetupPrerequisites()
    {
        
    }

    public void CollectStick() {
        m_trashCollected++;
        if(m_trashCollected >= 6) {
            GameManager.Instance.ProgressObjective();  
        }
    }
}
