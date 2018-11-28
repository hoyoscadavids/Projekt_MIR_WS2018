using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountains_Animation_Script : MonoBehaviour
{

    private ParticleSystem snow, mist;
    // Use this for initialization
    void Awake()
    {
        snow = GameObject.Find("Snow").GetComponent<ParticleSystem>();
        mist = GameObject.Find("Mist").GetComponent<ParticleSystem>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Plug"))
        {
            snow.Stop();
            mist.Stop();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Plug"))
        {
            snow.Play();
            mist.Play();
        }
    }


}
