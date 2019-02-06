using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Camera_Controller : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        this.transform.eulerAngles = new Vector3(GameObject.Find("First_Marker").transform.rotation.eulerAngles.x/4,
            GameObject.Find("First_Marker").transform.rotation.eulerAngles.y/4, 
            this.transform.eulerAngles.z) ;
	}
}
