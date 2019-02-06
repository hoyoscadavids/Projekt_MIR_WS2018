using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Controller : MonoBehaviour {
// Start the game activated (To fix some vuforia bugs)
	void Update () {
        this.GetComponent<SpriteRenderer>().enabled = true;
	}
}
