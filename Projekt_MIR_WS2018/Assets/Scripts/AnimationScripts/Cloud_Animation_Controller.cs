using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Cloud_Animation_Controller : MonoBehaviour {
    private Animator outerFrameAnimator, humanAnimator;
    // Use this for initialization
    void Awake () {
        outerFrameAnimator = GameObject.Find("Outer_Frame_Water").GetComponent<Animator>();
        humanAnimator = GameObject.Find("Human").GetComponent<Animator>();
    }

    private void Update()
    {
        if (isTrackingMarker("Marker_Three_Cloud"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
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

    private bool isTrackingMarker(string imageTargetName)
    {
        var imageTarget = GameObject.Find(imageTargetName);
        var trackable = imageTarget.GetComponent<TrackableBehaviour>();
        var status = trackable.CurrentStatus;
        return status == TrackableBehaviour.Status.TRACKED;
    }
}
