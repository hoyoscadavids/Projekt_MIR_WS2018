﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffectController : MonoBehaviour {
    private Vector3 newTransform;

    void Update () {
        // Set the water effect quad always as a fixed position in reference to the Island marker.
        newTransform = new Vector3(this.transform.position.x, this.transform.position.y, GameObject.Find("First_Marker").transform.position.z + 1);
        this.transform.position = newTransform;
    }
}
