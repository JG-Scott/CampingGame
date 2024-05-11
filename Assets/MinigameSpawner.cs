using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameSpawner : MonoBehaviour
{
    public GameObject Minigame;

    public Canvas HUDCanvas;

    private GameObject m_currentMinigame;

    public TentSetUpLogic TentSetUpObjective;

    private bool m_gameCreated = false;
    public void SpawnGame() 
    {
        m_currentMinigame = Instantiate(Minigame, HUDCanvas.transform);
        m_gameCreated = true;
    }

    private void Update() {
        if(m_gameCreated) {
            if(m_currentMinigame == null) {
                Destroy(gameObject);
                TentSetUpObjective.PegCompleted();
            }
        }
    }

}
