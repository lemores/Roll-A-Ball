using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{
 
    public float speed;
 /*   public Text countText;
    public Text WinText;
    public Text TimeText;
    public Text LifeText;
    public Text GameOverText;
    public GameObject BlurBackground;
    public GameObject WinnerMenu;
    public GameObject PausedMenu;
    public GameObject GameOverMenu;*/
    public Transform Player;
    public Transform RespawnPoint;


   /* [SerializeField] private string SceneToLoad;
    [SerializeField] private float DelayBeforeLoading;*/
    private Rigidbody rb;
   /* private float GameplayElapsed;
    private float TimeElapsed;
    private int count;
    private int Pick_Ups;*/
    private int LifeRemaining;
    bool Killed;

    private void Start()
    {
        Time.timeScale = 1f;
     /*   Pick_Ups = GameObject.FindGameObjectsWithTag("Pick Up").Length;
        LifeRemaining = 3;
       LifeText.text = "Lives  : " + LifeRemaining;*/
        rb = GetComponent<Rigidbody>();
     /*   SetCountText();
        count = 0;
        WinText.text = "";
        GameOverText.text = ""; */    
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

       /* WinMenu();
        PauseMenu();
        TimeCount();
        GameOver();*/
    }

    // In Contact with TRIGGERS
    private void OnTriggerEnter(Collider other)
    {
        // Pick Up
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
        }/*    count += 1;
            SetCountText();
        }*/

        // Kill floor
        if (other.gameObject.CompareTag("Kill"))
        {
            Player.transform.position = RespawnPoint.transform.position;
            Input.ResetInputAxes();
          //  LostingLives();
            Killed = true;
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;

            if (Killed == true)
            {
               rb.constraints = RigidbodyConstraints.None;
            }
        }
    }

/*// Setting TEXTS
    void SetCountText()
    {
        countText.text = "Count : " + count.ToString();

            if (count == Pick_Ups)
            {
                WinText.gameObject.SetActive(true);
                WinText.text = "You Win!";
            }
    }
    */
// Adding GAME OVER MENU
    void GameOver()
    {
        if(LifeRemaining < 0)
        {
        /*    TimeElapsed += Time.deltaTime;
            BlurBackground.SetActive(true);
            LifeText.text = "Lives : 0";
            GameOverText.text = "Game Over!";
            GameplayElapsed -= Time.deltaTime;*/
            rb.constraints = RigidbodyConstraints.FreezeAll;


        /*    if (TimeElapsed > DelayBeforeLoading)
            {
                GameOverMenu.gameObject.SetActive(true);
            }*/       
        }
    }
//}
/*// Adding WIN MENU 
    void WinMenu()
    {
        if (count == Pick_Ups)
        {
            TimeElapsed += Time.deltaTime;

            if (TimeElapsed > DelayBeforeLoading)
            {
                BlurBackground.SetActive(true);
                WinnerMenu.SetActive(true);
            }
        }
    }

// Adding PAUSE MENU
    void PauseMenu()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            Pause();
        }

        else if (Input.GetKey(KeyCode.Mouse0))
        {
            Resume();     
        }
    }     

// Configuring PAUSE
    void Pause()
    {
        BlurBackground.SetActive(true);
        PausedMenu.SetActive(true);
        Time.timeScale = 0f;
    }

// Configuring RESUME BUTTON
    public void Resume()
    {
        BlurBackground.SetActive(false);
        PausedMenu.SetActive(false);
        Time.timeScale = 1f;
    }

// Configuring NEXT LEVEL BUTTON
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

// Configuring RESTART BUTTON
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

// Configuring EXIT BUTTON
    public void ExitGame()
    {
        Application.Quit();
    }

// GameOver PLAYING AGAIN
    public void PlayAgain()
    {
        SceneManager.LoadScene("MiniGame");
    }

// Counting TIME
    void TimeCount()
    {
        GameplayElapsed += Time.deltaTime;
        TimeText.text = "Time : " + Math.Round(GameplayElapsed).ToString() + "s";

        // Stop counting
        if (count == Pick_Ups)
        {
            GameplayElapsed -= Time.deltaTime;
        }
    }
*/
// Losting LIVES
    void LostingLives()
    {
       LifeRemaining -= 1;
    }
}