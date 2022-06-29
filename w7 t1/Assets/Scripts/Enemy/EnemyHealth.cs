using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{   
    [SerializeField] private int startingHealth = 10;
    public int CurrentHealth { get { return currentHealth; } }
    int currentHealth;
    public Transform HealthBar;
    float ScaleHealthBar;

    CapsuleCollider capsuleCollider;
    SphereCollider sphereCollider;
    Animator anim;
    AudioSource enemyAudio;
    public AudioClip deathClip;

    [SerializeField] private Material color;


    void Awake()
    {
        ScaleHealthBar = HealthBar.localScale.x;
        currentHealth = startingHealth;
        capsuleCollider = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        sphereCollider = GetComponent<SphereCollider>();


    }
    public void TakeDamage(int amount)
    {
        color.color = Color.red;
        enemyAudio.Play();
        currentHealth -= amount;

        HealthBar.localScale = new Vector3(currentHealth * ScaleHealthBar / startingHealth, HealthBar.localScale.y, HealthBar.localScale.z);

        if (currentHealth <= 0)
        {
            HealthBar.localScale = new Vector3(0,0,0);
            Death();
        }
        StartCoroutine(ColorPlayer());
    }
    void Death()
    {
        anim.SetTrigger("Dead");
        Destroy(gameObject, 2f);
        capsuleCollider.enabled = false;// Player and bullets can pass through.
        sphereCollider.enabled = false;
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }

    private IEnumerator ColorPlayer()
    {
        yield return new WaitForSeconds(0.03f);
        color.color = Color.white;
    }
}
