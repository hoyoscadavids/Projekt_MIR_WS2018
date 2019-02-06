using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steam_Conroller : MonoBehaviour {
    private Animator outerFrameAnimator;
	// Use this for initialization
	void Awake() {
        outerFrameAnimator = GameObject.Find("Outer_Frame_Water").GetComponent<Animator>();
    }
	
	// Activate steam when water is being evaporated
	void Update () {
        if (outerFrameAnimator.GetBool("isSun")) { outerFrameAnimator.SetBool("isWater", false); }
		if(outerFrameAnimator.GetBool("isSun") && outerFrameAnimator.GetBool("isWater"))
        {
            GameObject.Find("Steam").GetComponent<ParticleSystem>().Play();
        }
        else
        {
            GameObject.Find("Steam").GetComponent<ParticleSystem>().Stop();
        }
	}
    void removingWaterAnimEnded()
    {
        outerFrameAnimator.SetBool("isWater", false);
    }
}
