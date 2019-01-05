using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain_Tilt_Animation_Controller : MonoBehaviour {
    Animator humanAnimator;
    [SerializeField]
    float edgeRotation, maxRotation;
	// Use this for initialization
	void Awake() {
        humanAnimator = GameObject.Find("Human").GetComponent<Animator>();
        edgeRotation = 0.2f;
        maxRotation = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.rotation.y <= -edgeRotation && this.transform.rotation.y > -maxRotation) {
            humanAnimator.SetBool("walkUp", true);
        }
        else if (this.transform.rotation.y >= edgeRotation && this.transform.rotation.y < maxRotation)
        {
         
            humanAnimator.SetBool("walkDown", true);
        }
    }   
}
