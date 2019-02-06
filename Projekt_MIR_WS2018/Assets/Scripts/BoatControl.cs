using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatControl : MonoBehaviour {
	// Add force to the boat to simulate movement in water.
	void Update () {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10f, 0f));
	}

}
