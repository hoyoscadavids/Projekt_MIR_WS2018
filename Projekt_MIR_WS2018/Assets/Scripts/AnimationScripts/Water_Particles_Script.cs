using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Particles_Script : MonoBehaviour {
    // Dispose of water particles when they are far away from the frame to reduce FPS lagg.
    void Update()
    {
        if (this.transform.position.y <= -20) { GameObject.Destroy(gameObject); }
    }
}
