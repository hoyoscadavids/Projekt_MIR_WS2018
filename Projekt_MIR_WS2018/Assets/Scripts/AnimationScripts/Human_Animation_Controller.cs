using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Animation_Controller : MonoBehaviour {

    
    void walkUpAnimationEnded()
    {
        gameObject.GetComponent<Animator>().SetBool("walkUp", false);
    }
    void walkDownAnimationEnded()
    {
        gameObject.GetComponent<Animator>().SetBool("walkDown", false);
    }
}
