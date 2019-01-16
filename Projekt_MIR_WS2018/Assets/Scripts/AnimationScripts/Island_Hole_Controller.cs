using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Island_Hole_Controller : MonoBehaviour {
    private void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    private void Update()
    {/*
        if (!isTrackingMarker("First_Marker"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }*/

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plug"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plug"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plug"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
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
