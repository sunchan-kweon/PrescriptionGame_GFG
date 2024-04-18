using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip clickaudio;
    private AudioSource audioSource;
    // public GameObject howtopanel;
    // public GameObject creditpanel;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clickaudio;
    }
    
    public void ToTitle()
    {
        audioSource.Play();
        SceneManager.LoadScene("Title");
    }

    public void ToPet()
    {
        audioSource.Play();
        SceneManager.LoadScene("Pet");
    }

    public void ToPuzzle()
    {
        audioSource.Play();
        SceneManager.LoadScene("Matcher");
        NeedsController.food -= Random.Range(5,10);
        NeedsController.energy -= Random.Range(5,10);
        NeedsController.happiness -= Random.Range(5,10);
    }

    public void ToSettings()
    {
        audioSource.Play();
        SceneManager.LoadScene("Settings");
    }

    public void ToInventory()
    {
        audioSource.Play();
        SceneManager.LoadScene("Inventory");
    }

    //GUIDEBOOK STUFF
    public void ToGuidebook()
    {
        audioSource.Play();
        SceneManager.LoadScene("Guidebook");
    }

    public void ToMetformin()
    {
        audioSource.Play();
        SceneManager.LoadScene("Guide_Metformin");
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
