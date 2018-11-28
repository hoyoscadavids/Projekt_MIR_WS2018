using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain_Collider_Frame_Controller : MonoBehaviour {
    private Animator waterOnMainFrameAnimator;
	// Use this for initialization
	void Start () {
        waterOnMainFrameAnimator = GameObject.Find("Water_Main_Marker").GetComponent<Animator>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
