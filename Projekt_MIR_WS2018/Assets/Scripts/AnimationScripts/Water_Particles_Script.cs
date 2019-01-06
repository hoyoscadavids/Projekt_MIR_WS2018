using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Particles_Script : MonoBehaviour {
    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= -20) { GameObject.Destroy(gameObject); }
    }
}
