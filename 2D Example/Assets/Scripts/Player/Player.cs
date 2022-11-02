using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] Animator animator;

    [SerializeField] LayerMask hitMask;
    [SerializeField] float maxHealth = 100;
    float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & hitMask.value) > 0)
        {
            animator.SetTrigger("Hit");
            currentHealth -= 10;
            rb.AddForce(new Vector2(1000 * -transform.localScale.x, 200));
            if(currentHealth < 0)
            {
                Die();
            }   
        }
    }

    void Die()
    {
        SceneManager.LoadScene(0);
    }
}
