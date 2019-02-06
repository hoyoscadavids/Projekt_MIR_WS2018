using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Human_Animation_Controller : MonoBehaviour {
    private GameObject front, side, head;
    private System.Random ran;
    private void Awake()
    {
        front = GameObject.Find("Human_Front_Pivot");
        side = GameObject.Find("Human_Side_Pivot");
        head = GameObject.Find("Kopf_Complete");
        ran = new System.Random();
        side.SetActive(false);
        InvokeRepeating("sayHello", 3.0f, 1f);
    }
 
    void sayHello()
    {
        // State random intervals for the human to say hello, when she is not freezing
        int randomNumber = ran.Next(0, 100);
        
        if(randomNumber <= 20)
        {
            gameObject.GetComponent<Animator>().SetBool("sayHello", true);
        }
    }

    // All the next functions are used in the animator controller
    void sayHelloAnimationEnded()
    {
        gameObject.GetComponent<Animator>().SetBool("sayHello", false);
    }

    void walkUpAnimationEnded()
    {
        gameObject.GetComponent<Animator>().SetBool("walkUp", false);
    }
    void walkDownAnimationEnded()
    {
        gameObject.GetComponent<Animator>().SetBool("walkDown", false);
    }

    // Changes between the side or front sprite
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
    // Lets the program know the human is currentently flying inside the hot air balloon
    void rideBalloon() {
        front.SetActive(false);
        side.SetActive(false);
        head.SetActive(true);
        gameObject.GetComponent<Animator>().SetBool("walkBackFromBalloon", false);
        gameObject.GetComponent<Animator>().SetBool("isRidingBalloon", true);
    }
    void playSound() {
        gameObject.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().Play();
    }
}
