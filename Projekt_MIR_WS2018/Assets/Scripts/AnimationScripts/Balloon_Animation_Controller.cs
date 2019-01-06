using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Animation_Controller : MonoBehaviour {
    private GameObject pfahl, head, side, front;
    private Animator humanAnimator;
    private bool headBool;
	// Use this for initialization
	void Awake () {
        head = GameObject.Find("Kopf_Complete");
        pfahl = GameObject.Find("Pfahl");
        side = GameObject.Find("Human_Side_Pivot");
        front = GameObject.Find("Human_Front_Pivot");
        humanAnimator = GameObject.Find("Human").GetComponent<Animator>();
        head.SetActive(false);
        headBool = false;
	}

    private void Update()
    {
       // headBool = humanAnimator.GetBool("isRidingBalloon");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pfahl") && !humanAnimator.GetBool("isRidingBalloon"))
        {
            humanAnimator.SetBool("walkToBalloon", true);
            humanAnimator.SetBool("walkBackFromBalloon", false);
        }
        else if (collision.gameObject.CompareTag("Pfahl") && humanAnimator.GetBool("isRidingBalloon")) {
            head.SetActive(false);
            humanAnimator.GetComponent<Animator>().SetBool("isRidingBalloon", false);
            humanAnimator.SetBool("walkBackFromBalloon", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pfahl") && !humanAnimator.GetBool("isRidingBalloon")) {
            humanAnimator.SetBool("walkToBalloon", false);
            humanAnimator.SetBool("walkBackFromBalloon", true);
        }
    }
}
