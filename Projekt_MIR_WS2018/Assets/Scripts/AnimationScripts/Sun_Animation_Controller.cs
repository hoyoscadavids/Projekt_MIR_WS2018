using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun_Animation_Controller : MonoBehaviour {
    private Animator outerFrameAnimator;
    // Use this for initialization
    void Awake()
    {
        outerFrameAnimator = GameObject.Find("Outer_Frame_Water").GetComponent<Animator>();
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Island") || other.gameObject.CompareTag("Mountains"))
        {
            outerFrameAnimator.SetBool("isSun", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Island") || other.gameObject.CompareTag("Mountains"))
        {
            outerFrameAnimator.SetBool("isSun", false);
        }
    }
}
