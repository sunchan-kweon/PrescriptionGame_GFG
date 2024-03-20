using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragBehavior : MonoBehaviour
{

    //This script is on a collider that follows the mouse/finger when that is an option
    [SerializeField]GameObject dragObject;
    List<GameObject> dragged = new List<GameObject> ();
    bool dragging = false;
    [SerializeField] GameGrid grid;
    [SerializeField] BerryMover mover;
    Vector3 mouseWorldPos;
    

    private void Update()
    {
        mouseWorldPos.z = 0f;
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragObject.transform.position = mouseWorldPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (dragging)
        {
            dragged.Add(collision.gameObject);
        }
    }

    bool checkList()
    {
        int prevId = dragged[0].GetComponent<Berry>().getId();
        int count = 0;
        int toMatch = dragged[0].GetComponent<Berry>().getNum2Match();

        for(int i = 1; i < dragged.Count; i++)
        {
            count++;
            if (prevId != dragged[i].GetComponent<Berry>().getId())
            {
                if(count != toMatch)
                {
                    return false;
                }
                else
                {
                    prevId = dragged[i].GetComponent<Berry>().getId();
                    count = 0;
                    toMatch = dragged[i].GetComponent<Berry>().getNum2Match();
                }
            }
        }
        count++;
        if (count != toMatch)
        {
            return false;
        }
        return true;
    }


    private void OnMouseDown()
    {
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging=false;
        if (checkList())
        {
            int[,] loc = new int[dragged.Count, 2];
            for(int i = 0; i < dragged.Count; i++)
            {
                loc[i, 0] =  (int)mover.revConX(dragged[i].transform.position.x);
                loc[i, 1] = (int)mover.revConY(dragged[i].transform.position.y);
            }
            grid.removeGroup(loc); //Make variable later for inventory

        }
    }
}
