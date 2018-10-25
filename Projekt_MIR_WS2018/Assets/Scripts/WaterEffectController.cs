using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffectController : MonoBehaviour {
    private Vector3 newTransform; 
	// Update is called once per frame
	void Update () {
        newTransform = new Vector3(this.transform.position.x, this.transform.position.y, GameObject.Find("First_Marker").transform.position.z);
        this.transform.position = newTransform;

	}
}
