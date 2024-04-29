using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;

public enum AnimationType {
    Oneshot, // for animations that will only play once, ie something falling over and staying there.
    Sequence, // something that has multiple animations played back to back,
    Reversable, // something that has animations that can go back and forth, like opening a door
    Selectable // something that has multiple animations and must do things depending on what is needed, use selection int in 'PlayAnimation' function.
}

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private AnimationType m_type;

    public List<String> AnimationNames;
    private bool m_finished = false;
    private Animator m_animator;

    private int m_animToPlay = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnimation(int selection = 0) 
    {
        if(!m_finished)
        {
            switch(m_type) {
                case AnimationType.Oneshot:
                // play animation
                m_finished = true;
                break;
                case AnimationType.Sequence:
                break;
                case AnimationType.Reversable:
                    m_animator.Play(AnimationNames[m_animToPlay]);
                    m_animToPlay = m_animToPlay == 0 ? 1 : 0;
                    break;
                    
                case AnimationType.Selectable:
                break;
            }
        }
    }
}
