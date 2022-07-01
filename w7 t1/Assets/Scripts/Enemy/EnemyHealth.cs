using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{   
    [SerializeField] private int startingHealth = 10;
    public int CurrentHealth { get { return currentHealth; } }
    int currentHealth;
    public Transform HealthBar;
    float ScaleHealthBar;

    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    SphereCollider sphereCollider;
    Animator anim;
    AudioSource enemyAudio;
    public AudioClip deathClip;

    [SerializeField] private Material color;

    [SerializeField] private int addScore;
    Score updateScore;

    void Awake()
    {
        ScaleHealthBar = HealthBar.localScale.x;
        currentHealth = startingHealth;
        capsuleCollider = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        sphereCollider = GetComponent<SphereCollider>();       
        updateScore = FindObjectOfType<Score>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
    }
    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        color.color = Color.red;
        enemyAudio.Play();

        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        currentHealth -= amount;
        HealthBar.localScale = new Vector3(currentHealth * ScaleHealthBar / startingHealth, HealthBar.localScale.y, HealthBar.localScale.z);

        if (currentHealth <= 0)
        {
            HealthBar.localScale = new Vector3(0,0,0);
            Death();
        }
        StartCoroutine(ColorPlayer());
    }
    public void Death()
    {
        anim.SetTrigger("Dead");
        Destroy(gameObject, 2f);
        capsuleCollider.enabled = false;// Player and bullets can pass through.
        sphereCollider.enabled = false;
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
        updateScore.ScoreUpdate(addScore);
    }

    private IEnumerator ColorPlayer()
    {
        yield return new WaitForSeconds(0.03f);
        color.color = Color.white;
    }
}
