using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // public GameObject howtopanel;
    // public GameObject creditpanel;
    
    public void ToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void ToPet()
    {
        SceneManager.LoadScene("Pet");
    }

    public void ToPuzzle()
    {
        SceneManager.LoadScene("Matcher");
        NeedsController.food -= 5;
        NeedsController.energy -= 10;
    }

    public void ToSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ToInventory()
    {
        SceneManager.LoadScene("Inventory");
    }

    //GUIDEBOOK STUFF
    public void ToGuidebook()
    {
        SceneManager.LoadScene("Guidebook");
    }

    public void ToMetformin()
    {
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
