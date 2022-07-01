using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class GameOverPannel : MonoBehaviour
{
    public AudioMixerSnapshot Nommal;
    public AudioMixerSnapshot GameOver;
    public Health health;
    Canvas canvas;
    Button button;
    private void Awake()
    {
        health = FindObjectOfType<Health>();
        canvas = GetComponent<Canvas>();
        button = GetComponentInChildren<Button>();
        canvas.enabled = false;
    }
    public void gameOver()
    {
        if(health.currentHealth == 0)
        {
            canvas.enabled = true;
            GameOver.TransitionTo(3f);
        }
    }
    public void playAgain()
    {
        Nommal.TransitionTo(0.1f);
        SceneManager.LoadScene(0);
    }
}
