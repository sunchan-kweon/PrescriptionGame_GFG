using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //Timer values
    public float readytime = 3;
    public float countdowntime = 90;
    public float remainingtime;

    //Timer UI
    public TextMeshProUGUI readyText;
    public TextMeshProUGUI countdownText;
    
    //Pause menu UI
    public GameObject goText;
    public GameObject finishText;
    public GameObject pausePanel;

    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        remainingtime = countdowntime;
        readyText.text = readytime.ToString("F0");
        countdownText.text = countdowntime.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!isPaused)
        {
            //Give players 3 seconds before start of the game and before game is unpaused
            if(readytime > 0)
            {
                readytime -= Time.deltaTime;
                readyText.text = readytime.ToString("F0");
            }

            if(readytime <= 1)
            {
                readyText.enabled = false;
                goText.SetActive(true);
                readytime -= Time.deltaTime;
            }
            
            if(readytime <= 0)
            {
                goText.SetActive(false);
                countdowntime -= Time.deltaTime;
                countdownText.text = countdowntime.ToString("F0");
            }

            //Finish game if count down is 0
            if(countdowntime <= 0)
            {
                finishText.SetActive(true);
                countdownText.text = "0";
            }

            //Show results 3 seconds after game is finished
            if(countdowntime <= -3)
            { 
                SceneManager.LoadScene("Result");
            }

        }
        
    }

    public void Pause()
    {
        //unpause game with recounting the ready timer
        if(isPaused)
        {
            pausePanel.SetActive(false);
            readytime = 3;
            readyText.enabled = true;
            isPaused = false;
        }
        //pause game
        else
        {
            pausePanel.SetActive(true);
            isPaused = true;
        }
    }
}
