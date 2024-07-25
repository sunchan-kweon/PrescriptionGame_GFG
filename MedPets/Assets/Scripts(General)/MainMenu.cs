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
        NeedsController.blood -= Random.Range(5,10);
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

    public void ToTutorial()
    {
        audioSource.Play();
        SceneManager.LoadScene("Tutorial");
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

    public void ToInsulin()
    {
        audioSource.Play();
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
