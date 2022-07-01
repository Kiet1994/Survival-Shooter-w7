using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int MaxHP = 10;
    public Transform HealthBar;
    float ScaleHealthBar;
    private int CurrentHealth { get { return currentHealth; } }
    public int currentHealth;
    public Slider healthSlider;

    Animator anim;
    PlayerMovement playerMovement;
    PlayerAttack playerAttack;
    AudioSource playerHurtAudio;
    public AudioClip deathClip;
    GameOverPannel gameOver;

    void Awake()
    {
        ScaleHealthBar = HealthBar.localScale.x;
        anim = GetComponent<Animator>();
        playerHurtAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponentInChildren<PlayerAttack>();
        currentHealth = MaxHP;
        healthSlider.maxValue = MaxHP;
        healthSlider.value = currentHealth;
        gameOver = FindObjectOfType<GameOverPannel>();
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        HealthBar.localScale = new Vector3(currentHealth * ScaleHealthBar / MaxHP, HealthBar.localScale.y, HealthBar.localScale.z);
        healthSlider.value = currentHealth;

        playerHurtAudio.Play();

        if (currentHealth <= 0)
        {
            Death();
            HealthBar.localScale = new Vector3(0, 0, 0);
        }
    }
    void Death()
    {
        playerHurtAudio.clip = deathClip;// add vô 
        playerHurtAudio.Play(); //thực hiện 

        anim.SetTrigger("Die");
        playerMovement.enabled = false;
        playerAttack.enabled = false;
        gameOver.gameOver();

    }
}
