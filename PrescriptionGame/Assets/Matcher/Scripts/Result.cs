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
        Inventory.caffeine += DragBehavior.caffeinecount % 20;
        Inventory.insulin += DragBehavior.insulincount % 30;
        Inventory.metformin += DragBehavior.metformincount % 30;
        SaveSystem.SavePet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
