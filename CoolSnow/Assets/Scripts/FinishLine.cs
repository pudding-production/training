using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] AudioClip[] audioClips;

    AudioSource audioSource;
    bool alreadyWon = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!alreadyWon)
            {
                alreadyWon = true;
                Invoke("ResetLevel", delay);
                audioSource.PlayOneShot(RandomWinSound());
                finishEffect.Play();
            }
        }
    }

    private AudioClip RandomWinSound()
    {
        return audioClips[Random.Range(0, 4)];
    }

    void ResetLevel()
    {
        SceneManager.LoadScene(0);
    }

}
