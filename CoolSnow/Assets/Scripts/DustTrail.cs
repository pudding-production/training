using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustParticle;

    bool particleActive = true;

    void OnCollisionExit2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Stop dust");
            dustParticle.Stop();
        } 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (particleActive)
            {
                dustParticle.Play();
            }
        }
    }
}
