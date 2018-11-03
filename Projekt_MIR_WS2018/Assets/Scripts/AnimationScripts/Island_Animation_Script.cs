using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island_Animation_Script : MonoBehaviour {
    private Animator islandAnimator;
    private bool noWater;
    private Collider2D constraints;
    private int waterParticlesOutCounter;
    private int maxNumberOfWaterParticles;
    private bool dyingIslandAnimationTriggered;
	// Use this for initialization
	void Awake () {
        islandAnimator = GameObject.Find("Island").GetComponent<Animator>();
        constraints = this.GetComponent<BoxCollider2D>();
        noWater = false;
        waterParticlesOutCounter = 0;
        maxNumberOfWaterParticles = 150;
        dyingIslandAnimationTriggered = false;  
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D other){
        
        if (other.gameObject.CompareTag("Water"))
            waterParticlesOutCounter++;
        {
            if (waterParticlesOutCounter >= (maxNumberOfWaterParticles - maxNumberOfWaterParticles/3) && !dyingIslandAnimationTriggered)
            {
                dyingIslandAnimationTriggered = true;
                islandAnimator.SetBool("noWater", true);
            }
        }
        
         
    }
}
