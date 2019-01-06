using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Animation_Controller : MonoBehaviour {
    private GameObject front, side, head;

    private void Awake()
    {
        front = GameObject.Find("Human_Front_Pivot");
        side = GameObject.Find("Human_Side_Pivot");
        head = GameObject.Find("Kopf_Complete");
        side.SetActive(false);
    }
    void walkUpAnimationEnded()
    {
        gameObject.GetComponent<Animator>().SetBool("walkUp", false);
    }
    void walkDownAnimationEnded()
    {
        gameObject.GetComponent<Animator>().SetBool("walkDown", false);
    }
    void changeToFront() {
        front.SetActive(true);
        side.SetActive(false);
    }
    void changeToSide() {
        front.SetActive(false);
        side.SetActive(true);
    }

    void walkToBalloonAnimationEnded() {
        gameObject.GetComponent<Animator>().SetBool("walkToBalloon", false);
    }
    void walkBackFromBalloonAnimationEnded()
    {
        Debug.Log("hi");
        gameObject.GetComponent<Animator>().SetBool("walkBackFromBalloon", false);
    }

    void rideBalloon() {
        front.SetActive(false);
        side.SetActive(false);
        head.SetActive(true);
        gameObject.GetComponent<Animator>().SetBool("walkBackFromBalloon", false);
        gameObject.GetComponent<Animator>().SetBool("isRidingBalloon", true);
    }
}
