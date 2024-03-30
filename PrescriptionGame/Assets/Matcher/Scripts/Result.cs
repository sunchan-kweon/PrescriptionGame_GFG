using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Result : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = GameGrid.score.ToString("D6");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
