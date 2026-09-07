using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFX : MonoBehaviour
{
    public Text countText;
    public AudioSource VictoryTheme;
    public AudioSource Backgroundsound;
    public AudioSource CollectedSound;
    public AudioSource GameOverTheme;

    private int LifeRemaining;
    private int Pick_Ups;
    private int count;

    void Start()
    {
        count = 0;
        Pick_Ups = GameObject.FindGameObjectsWithTag("Pick Up").Length;
        LifeRemaining = 3;
    }

// In Contact with PICK UP
   private void OnTriggerEnter(Collider other)
   {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            StartVictoryTheme();
            CollectedObjectSound();           
        }

        // Kill floor
        if (other.gameObject.CompareTag("Kill"))
        {
            LifeRemaining -= 1;
            GameOver();
        }


 // Configuring VICTORY THEME
    void StartVictoryTheme()
    {
        if (count == Pick_Ups)
        {
           DisablingBackgroundSound();
           VictoryTheme.Play();
        }
    }

 // Disabling BACKGROUND SOUND
    void DisablingBackgroundSound()
    {
        Backgroundsound.enabled = false;
    }

 // Adding COLLECTED OBJECT SOUND
    void CollectedObjectSound()
    {
         CollectedSound.Play();
    }

// Configuring GAME OVER THEME
    void GameOver()
    {
       if (LifeRemaining == -1)
       {
            GameOverTheme.Play();
            DisablingBackgroundSound();
       }
    }
    }
}