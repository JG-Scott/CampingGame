using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectiveID {
    Start,
    CampCleanUp,
    TentSetUp,
    CookingSetUp,
}

public class Objective : MonoBehaviour
{
    protected int m_currentComponentIndex = -1;
    public ObjectiveComponent[] components;
    public ObjectiveID ID;

    public Objective NextObjective;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetNextComponent() {
        m_currentComponentIndex++;
        if(m_currentComponentIndex >= components.Length) {
            GameManager.Instance.ProgressObjective(NextObjective);
        } else {
            HandleNextComponent();
        }
    }

    public string GetComponentText()
    {
        return components[m_currentComponentIndex].ObjectiveText;
    }

    public virtual void SetupPrerequisites() {

    }

    public virtual void HandleNextComponent() {}
}
