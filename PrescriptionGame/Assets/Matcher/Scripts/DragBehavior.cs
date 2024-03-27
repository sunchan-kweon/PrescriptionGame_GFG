using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragBehavior : MonoBehaviour
{

    //This script is on a collider that follows the mouse/finger when that is an option
    [SerializeField]List<GameObject> dragged = new List<GameObject> ();
    bool dragging = false;
    [SerializeField] GameGrid grid;
    [SerializeField] BerryMover mover;
    [SerializeField] CircleCollider2D col;
    Vector3 mouseWorldPos;
    
    private void Update()
    {
        mouseWorldPos.z = 0f;
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseWorldPos;

        if (Input.GetMouseButtonDown(0))
        {
            onDown();
        }
        if (Input.GetMouseButtonUp(0))
        {
            onUp();
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (dragging)
        {
            if(collider.gameObject.GetComponent<Berry>().added == false)
            {
                dragged.Add(collider.gameObject);
                collider.gameObject.GetComponent<Berry>().added = true;
            }
            
        }
    }

    bool checkList()
    {
        if(dragged.Count > 0)
        {
            int prevId = dragged[0].GetComponent<Berry>().getId();
            int count = 0;
            int toMatch = dragged[0].GetComponent<Berry>().getNum2Match();

            for (int i = 1; i < dragged.Count; i++)
            {
                count++;
                if (prevId != dragged[i].GetComponent<Berry>().getId())
                {
                    if (count != toMatch)
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
        return false;
    }

    public void onUp()
    {
        dragging = false;
        col.enabled = false;
        if (checkList())
        {
            int[,] loc = new int[dragged.Count, 2];
            for (int i = 0; i < dragged.Count; i++)
            {
                loc[i, 0] = dragged[i].GetComponent<Berry>().getX();
                loc[i, 1] = dragged[i].GetComponent<Berry>().getY();
            }
            clearAdded();
            grid.addScore(dragged.Count * 100);
            grid.removeGroup(loc); //Make variable later for inventory
            dragged.Clear();
        }
        else
        {
            clearAdded();
            dragged.Clear();
        }
    }

    void clearAdded()
    {
        for (int i = 0; i < dragged.Count; i++)
        {
            dragged[i].GetComponent<Berry>().added = false;
        }
    }

    public void onDown()
    {
        dragging = true;
        col.enabled = true;
    }
}
