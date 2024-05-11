using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampEnteranceTrigger : MonoBehaviour
{
    public GameObject CampCooler;
    public GameObject CampPack;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponentInChildren<PlayerCarryLogic>().Detach();
            CampCooler.SetActive(true);
            CampPack.SetActive(true);
            GameManager.Instance.ProgressObjective();
            Destroy(gameObject);
        }    
    }
}
