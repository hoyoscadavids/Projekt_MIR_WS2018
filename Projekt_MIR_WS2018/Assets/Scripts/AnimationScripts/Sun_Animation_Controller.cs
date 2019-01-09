using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Sun_Animation_Controller : MonoBehaviour {
    private Animator outerFrameAnimator;
    // Use this for initialization
    void Awake()
    {
        outerFrameAnimator = GameObject.Find("Outer_Frame_Water").GetComponent<Animator>();
    }
    private void Update()
    {
        if (isTrackingMarker("Target_Six_Sun")) {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            gameObject.GetComponentInChildren<Light>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponentInChildren<Light>().enabled = false;
        }
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

    private bool isTrackingMarker(string imageTargetName)
    {
        var imageTarget = GameObject.Find(imageTargetName);
        var trackable = imageTarget.GetComponent<TrackableBehaviour>();
        var status = trackable.CurrentStatus;
        return status == TrackableBehaviour.Status.TRACKED;
    }
}
