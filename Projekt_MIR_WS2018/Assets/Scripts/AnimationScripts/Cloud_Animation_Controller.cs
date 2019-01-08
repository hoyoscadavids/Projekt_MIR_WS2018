using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_Animation_Controller : MonoBehaviour {
    private Animator outerFrameAnimator, humanAnimator;
    // Use this for initialization
    void Awake () {
        outerFrameAnimator = GameObject.Find("Outer_Frame_Water").GetComponent<Animator>();
        humanAnimator = GameObject.Find("Human").GetComponent<Animator>();
    }
	

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Island") || other.gameObject.CompareTag("Mountains"))
        {
            outerFrameAnimator.SetBool("isWater", true);
        }
        if (other.gameObject.CompareTag("Mountains"))
        {
            humanAnimator.SetBool("isCloud", false);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mountains"))
        {
            humanAnimator.SetBool("isCloud", true);
        }
    }
}
