using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // public GameObject howtopanel;
    // public GameObject creditpanel;
    
    public void ToPet()
    {
        SceneManager.LoadScene("Pet");
    }

    public void ToPuzzle()
    {
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
