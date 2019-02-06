using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain_Tilt_Animation_Controller : MonoBehaviour {
    Animator humanAnimator;
    GameObject side;
    [SerializeField]
    float edgeRotation, maxRotation;
	// Use this for initialization
	void Awake() {
        humanAnimator = GameObject.Find("Human").GetComponent<Animator>();
        side = GameObject.Find("side_body");
        edgeRotation = 0.2f;
        maxRotation = 0.5f;
	}
	
	// Activate the "walking up/down the mountain" animation, taking into account the min and max rotation
    // when tilting the frame
	void Update () {
        if (this.transform.rotation.y <= -edgeRotation && this.transform.rotation.y > -maxRotation)
        {
            humanAnimator.SetBool("walkUp", true);
            humanAnimator.SetBool("walkDown", false);
        }
        else
        {
            humanAnimator.SetBool("walkUp", false);
            humanAnimator.SetBool("walkDown", true);
        }
    }   
}
