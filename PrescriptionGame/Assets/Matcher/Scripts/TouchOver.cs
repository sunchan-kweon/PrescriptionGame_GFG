using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchOver : MonoBehaviour
{

    [SerializeField] DragBehavior drag;
    [SerializeField] Berry berry;

    private void Start()
    {
        drag = GameObject.FindWithTag("Detector").GetComponent<DragBehavior>();
    }

    private void OnMouseOver()
    {
        if (drag.isDragging() && berry.added == false)
        {
            drag.addDragged(gameObject);
            berry.added = true;
            drag.drawLines();
        }
        
    }

}
