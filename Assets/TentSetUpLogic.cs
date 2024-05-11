using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentSetUpLogic : MonoBehaviour
{


    [SerializeField] GameObject m_tent;
    [SerializeField] int m_pegsCompleted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CompleteTent() {
        m_tent.SetActive(true);
        // HUDController.Instance.DisplayObjective("Set up camp fire");  
    }

    public void PegCompleted() {
        m_pegsCompleted++;
        if(m_pegsCompleted >= 4) {
            CompleteTent();
            GameManager.Instance.ProgressObjective();  
            Destroy(gameObject);
        }
    }
}
