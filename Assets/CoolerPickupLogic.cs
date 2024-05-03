using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolerPickupLogic : MonoBehaviour
{
    public GameObject HoldObject;
    public void PickUp() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponentInChildren<PlayerCarryLogic>().Attach(HoldObject);
        gameObject.SetActive(false);

    }
}
