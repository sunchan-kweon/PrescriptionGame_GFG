using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameGrid.score = 0;
        DragBehavior.insulincount = 0;
        DragBehavior.caffeinecount = 0;
        DragBehavior.metformincount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
