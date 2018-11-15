using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<SpriteRenderer>().enabled = true;
	}
}
