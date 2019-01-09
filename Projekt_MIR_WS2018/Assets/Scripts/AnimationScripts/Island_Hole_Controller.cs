using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island_Hole_Controller : MonoBehaviour {
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plug"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plug"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
