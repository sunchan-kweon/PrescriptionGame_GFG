using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip clickaudio;
    private AudioSource audioSource;
    public GameObject mask;
    public GameObject maskPrefab;
    public RectTransform parent;
    private static bool tutorialFinished;
    // public GameObject howtopanel;
    // public GameObject creditpanel;

    void Start()
    {
        if(audioSource != null)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = clickaudio;
        }
    }
    
    public void ToTitle()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        SceneManager.LoadScene("Title");
    }

    public void ToPet()
    {
        if(audioSource != null)
        {
            audioSource.Play();
        }
        SceneManager.LoadScene("Pet");
    }

    public void ToTutorial()
    {
        if (!tutorialFinished)
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
            SceneManager.LoadScene("Tutorial");
            tutorialFinished = true;
        }
        else
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
            SceneManager.LoadScene("Pet");
        }
    }

    public void ToPuzzle()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        if (mask != null)
        {
            StartCoroutine(Fade());
        }
        else
        {
            mask = Instantiate(maskPrefab, parent);
            StartCoroutine(Fade());
        }
        NeedsController.food -= Random.Range(10,20);
        NeedsController.energy += Random.Range(20,40);
        NeedsController.blood -= Random.Range(20, 40);
    }

    public void ToSettings()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        SceneManager.LoadScene("Settings");
    }

    public void ToInventory()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        SceneManager.LoadScene("Inventory");
    }

    //GUIDEBOOK STUFF
    public void ToGuidebook()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        SceneManager.LoadScene("Guidebook");
    }

    public void ToMetformin()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        SceneManager.LoadScene("Guide_Metformin");
    }

    public void ToInsulin()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        SceneManager.LoadScene("Guide_Insulin");
    }

    IEnumerator Fade()
    {
        mask.SetActive(true);
        yield return new WaitForSeconds(2.1f);
        SceneManager.LoadScene("Matcher");

    }

    // public void Credits()
    // {
    //     creditpanel.SetActive(true);
    //     howtopanel.SetActive(false);
    // }

    // public void ExitGame ()
    // {
    //     Application.Quit();
    // }
}
