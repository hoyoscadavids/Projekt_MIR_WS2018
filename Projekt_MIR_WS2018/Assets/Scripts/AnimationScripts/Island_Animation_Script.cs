    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island_Animation_Script : MonoBehaviour {
    private Animator islandAnimator;
    private bool noWater;
    private bool isCloud;
    private Collider2D constraints;
    private int waterParticlesOutCounter;
    private int maxNumberOfWaterParticles;
    private bool dyingIslandAnimationTriggered;
    public GameObject waterPrefab;
    private GameObject waterParent;
	// Use this for initialization
	void Awake () {
        islandAnimator = GameObject.Find("Island").GetComponent<Animator>();
        constraints = this.GetComponent<BoxCollider2D>();
        waterParticlesOutCounter = 0;
        maxNumberOfWaterParticles = 150;
        dyingIslandAnimationTriggered = false;
        waterParent = GameObject.Find("Water");
	}

    private void FixedUpdate()
    {
        if(waterParticlesOutCounter > 0 && islandAnimator.GetBool("isCloud")){
            Instantiate(waterPrefab, waterParent.transform);
            waterParticlesOutCounter--;
        }
        if(waterParticlesOutCounter <= maxNumberOfWaterParticles / 2)
        {
            islandAnimator.SetBool("noWater", false);
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        
        if (other.gameObject.CompareTag("Water"))
            waterParticlesOutCounter++;
        {
            if (waterParticlesOutCounter >= (maxNumberOfWaterParticles - maxNumberOfWaterParticles/3) /*&& !dyingIslandAnimationTriggered*/)
            {
               // dyingIslandAnimationTriggered = true;
                islandAnimator.SetBool("noWater", true);
            }
        }
        if (other.gameObject.CompareTag("Cloud"))
        {
            islandAnimator.SetBool("isCloud", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.CompareTag("Cloud"))
        {
            Debug.Log("Water is being inserted");
            islandAnimator.SetBool("isCloud", true);
        }
    }
}
