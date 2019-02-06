using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Cloud_Animation_Controller : MonoBehaviour {
    private Animator outerFrameAnimator, humanAnimator;
    private int collisions, timeOutCollisions;
    // Use this for initialization
    void Awake () {
        outerFrameAnimator = GameObject.Find("Outer_Frame_Water").GetComponent<Animator>();
        humanAnimator = GameObject.Find("Human").GetComponent<Animator>();
        collisions = 0;
    }

    private void Update()
    {
        // Cloud is detected as outside the frames after 1 second.
        if (isTrackingMarker("Marker_Three_Cloud"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            if (collisions == 0)
            {
                timeOutCollisions++;
                if(timeOutCollisions >= 60)
                {
                    outerFrameAnimator.SetBool("isWater", true);
                }
            }
            else { timeOutCollisions = 0; }
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;   
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Set the amount of collisions for the code in update.
        if (other.gameObject.CompareTag("Island") || other.gameObject.CompareTag("Mountains"))
        {
            collisions--;
        }
        if (other.gameObject.CompareTag("Mountains"))
        {
            humanAnimator.SetBool("isCloud", false);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Set the amount of collisions for the code in update.
        collisions++;
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
