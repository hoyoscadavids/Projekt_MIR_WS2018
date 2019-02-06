using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Island_Animation_Script : MonoBehaviour {
    private Animator islandAnimator, outerFrameAnimator;
    private bool noWater;
    private bool isCloud;
    private Collider2D constraints;
    private int waterParticlesOutCounter;
    private int waterParticlesInCounter;
    private int maxNumberOfWaterParticles;
    private bool dyingIslandAnimationTriggered;
    public GameObject waterPrefab;
    private GameObject waterParent;
	// Use this for initialization
	void Awake () {
        islandAnimator = GameObject.Find("Island").GetComponent<Animator>();
        outerFrameAnimator = GameObject.Find("Outer_Frame_Water").GetComponent<Animator>();
        constraints = this.GetComponent<BoxCollider2D>();
        waterParticlesOutCounter = 0;       
        dyingIslandAnimationTriggered = false;
        waterParent = GameObject.Find("Water");
        noWater = false;
        maxNumberOfWaterParticles = 200;
        waterParticlesInCounter = maxNumberOfWaterParticles;
	}
   

    private void FixedUpdate()
    {
        // When the cloud is in the frame, and the frame doesn't have the normal amount o water, fill it with water.
        if(noWater && islandAnimator.GetBool("isCloud") && waterParticlesInCounter < maxNumberOfWaterParticles){
            GameObject waterDrop = Instantiate(waterPrefab, waterParent.transform);
            waterDrop.transform.position = GameObject.Find("Marker_Three_Cloud").transform.position;
            waterParticlesInCounter++;
            
        }
        if(waterParticlesInCounter == maxNumberOfWaterParticles)
        {          
            noWater = false;
        }
        if(waterParticlesInCounter >= maxNumberOfWaterParticles / 2)
        {
            islandAnimator.SetBool("noWater", false);
        }
    }

    private void Update()
    {
        // Deactivate water when not being tracked
        if (!isTrackingMarker("First_Marker"))
        {
            for (int i = 0; i < waterParent.transform.childCount; i++)
            {
                waterParent.transform.GetChild(i).gameObject.SetActive(false);
            }         
        }
        else
        {
            for (int i = 0; i < waterParent.transform.childCount; i++)
            {
                waterParent.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        // Reset number of out particles when they are disposed of.
        if(waterParticlesOutCounter >= maxNumberOfWaterParticles)
        {
            waterParticlesOutCounter = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        // Detect water leaving the frame
        if (other.gameObject.CompareTag("Water"))
            waterParticlesOutCounter++;
            waterParticlesInCounter--;
        {
            if (waterParticlesOutCounter >= (maxNumberOfWaterParticles - maxNumberOfWaterParticles/3) && other.gameObject.CompareTag("Water"))
            {
                // If enough water leaves trigger the plants dying animation
                islandAnimator.SetBool("noWater", true);
                outerFrameAnimator.SetBool("isWater", true);
                noWater = true;
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
            islandAnimator.SetBool("isCloud", true);
        }
    }
    private bool isTrackingMarker(string imageTargetName)
    {
        var imageTarget = GameObject.Find(imageTargetName);
        var trackable = imageTarget.GetComponent<TrackableBehaviour>();
        var status = trackable.CurrentStatus;
        return status == TrackableBehaviour.Status.TRACKED;
    }
}
