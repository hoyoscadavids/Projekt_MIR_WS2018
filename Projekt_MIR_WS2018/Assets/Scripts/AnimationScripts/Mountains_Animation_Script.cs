using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountains_Animation_Script : MonoBehaviour
{
    private ParticleSystem snow, mist;
    private Animator humanAnimator;
    // Use this for initialization
    void Awake()
    {
        snow = GameObject.Find("Snow").GetComponent<ParticleSystem>();
        mist = GameObject.Find("Mist").GetComponent<ParticleSystem>();
        humanAnimator = GameObject.Find("Human").GetComponent<Animator>();

    }

    // Activate snow and mist when no Plug is colliding with the whole in the mountain.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Plug"))
        {
            humanAnimator.SetBool("isPlug", true);
            snow.Stop();
            mist.Stop();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Plug"))
        {
            humanAnimator.SetBool("isPlug", false);
            snow.Play();
            mist.Play();
        }
    }


}
