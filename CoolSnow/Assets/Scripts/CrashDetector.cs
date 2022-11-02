using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    
    [SerializeField] AudioClip crashSFX;

    [SerializeField] PlayerMovement playerMovement;

    bool alreadyHit = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            playerMovement.DisableControls();

            Invoke("ResetLevel", delay);
            
            if (!alreadyHit)
            {
                alreadyHit = true;
                crashEffect.Play();
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
            }
            
        }
    }

    void ResetLevel()
    {
        SceneManager.LoadScene(0);
    }
}
