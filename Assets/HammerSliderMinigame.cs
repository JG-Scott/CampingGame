using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HammerSliderMinigame : MonoBehaviour
{

    [SerializeField] private Slider m_slider;

    [SerializeField] private Slider m_rightBlockSlider;

    [SerializeField] private Slider m_leftBlockSlider;
    [SerializeField] private float m_sliderSpeed;
    [SerializeField] private float m_triggerAreaSize = 0.15f;

    private bool m_doRun = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_doRun) {
            m_slider.value = Mathf.Sin(Time.time*m_sliderSpeed);

            if(Input.GetKeyDown(KeyCode.Space)) {
               
                if(m_slider.value > (m_leftBlockSlider.value*2)-1 && m_slider.value < 1 - (m_rightBlockSlider.value*2)) {
                    StartCoroutine(PauseForASecondAfterHit(0.5f));
                    m_sliderSpeed += 2;
                } else {
                    // play hammer hitting ground sound effect, play player saying darn it sound effect.
                    Debug.Log("Fail");
                    StartCoroutine(PauseForASecondAfterHit(0.5f));
                }
            } 

            if(m_sliderSpeed > 6) {
                GameOver();
            }
        }

        
    }

    private void GameOver() {
        Destroy(gameObject);
    }


    private void ChangeSliders() {
        float tempValue = Random.Range(0f, .85f);
        m_leftBlockSlider.value = tempValue;
        m_rightBlockSlider.value = 1f - (tempValue + m_triggerAreaSize);
                    //play ding sound effect and animation
    }


    public IEnumerator PauseForASecondAfterHit(float time) {
        // set boolean to like is displaying
        m_doRun = false;
        yield return new WaitForSeconds(time);
        m_doRun = true;
        ChangeSliders();
        
    }
}
