using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TentPlacementAreaTrigger : MonoBehaviour
{

    public string ObjectTag;
    public UnityEvent OnInteraction;

    public bool RequiresObject = true;
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
            if(RequiresObject){
                if(other.gameObject.GetComponentInChildren<PlayerCarryLogic>().CurrentHeldGameObjectTag() == ObjectTag) {
                    other.gameObject.GetComponentInChildren<PlayerCarryLogic>().Detach();
                    OnInteraction.Invoke();
                }
            } else {
                OnInteraction.Invoke();
                Destroy(gameObject);
            }
        }    
    }
}
