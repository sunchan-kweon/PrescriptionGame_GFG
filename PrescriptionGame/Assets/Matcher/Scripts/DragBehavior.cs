using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragBehavior : MonoBehaviour
{
    public static int caffeinecount;
    public static int insulincount;
    public static int metformincount;

    //This script is on a collider that follows the mouse/finger when that is an option
    [SerializeField]List<GameObject> dragged = new List<GameObject> ();
    bool dragging = false;
    [SerializeField] GameGrid grid;
    [SerializeField] BerryMover mover;
    [SerializeField] BerryHolder holder;
    [SerializeField] CircleCollider2D col;
    [SerializeField] LineRenderer line;
    Vector3 mouseWorldPos;
    
    private void Update()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
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

    /*private void OnCollisionEnter2D(Collision2D collider)
    {
        if (dragging)
        {
            if(collider.gameObject.GetComponent<Berry>().added == false)
            {
                dragged.Add(collider.gameObject);
                collider.gameObject.GetComponent<Berry>().added = true;
                drawLines();
            }
            
        }
    }*/

    int checkList()
    {
        if(dragged.Count > 0)
        {
            int prevId = dragged[0].GetComponent<Berry>().getId();
            int count = 0;
            int toMatch = dragged[0].GetComponent<Berry>().getNum2Match();
            int[] ids = new int[holder.getSize()];
            int chains = 1;

            for (int i = 1; i < dragged.Count; i++)
            {
                count++;
                if (prevId != dragged[i].GetComponent<Berry>().getId())
                {
                    if (count != toMatch)
                    {
                        return -1;
                    }
                    else //This is when 
                    {
                        ids[prevId] = 1;
                        for(int j = 0; j < dragged[i].GetComponent<Berry>().getIncomp().Length; j++)
                        {
                            if (ids[dragged[i].GetComponent<Berry>().getIncomp()[j]] == 1)
                            {
                                return -1;
                            }
                        }
                        prevId = dragged[i].GetComponent<Berry>().getId();
                        count = 0;
                        chains++;
                        toMatch = dragged[i].GetComponent<Berry>().getNum2Match();
                    }
                }
            }
            count++;
            if (count != toMatch)
            {
                return -1;
            }
            return chains;
        }
        return -1;
    }

    public void onUp()
    {
        dragging = false;
        col.enabled = false;
        int chains = checkList();
        if (chains != -1)
        {
            int[,] loc = new int[dragged.Count, 2];
            for (int i = 0; i < dragged.Count; i++)
            {
                loc[i, 0] = dragged[i].GetComponent<Berry>().getX();
                loc[i, 1] = dragged[i].GetComponent<Berry>().getY();
            }
            clearAdded();
            int clearid = dragged[0].GetComponent<Berry>().getId();
            switch(clearid){
                case 0:
                    insulincount += 3;
                    break;
                case 1:
                    metformincount += 3;
                    break;
                case 2:
                    caffeinecount += 3;
                    break;
                default:
                    break;

            }
            grid.addScore(dragged.Count * 100);
            grid.removeGroup(loc); //Make variable later for inventory
            dragged.Clear();
        }
        else
        {
            clearAdded();
            dragged.Clear();
        }
        line.positionCount = 0;
    }

    public void drawLines()
    {
        if(checkList() >= 0)
        {
            line.startColor = Color.green;
            line.endColor = Color.green;
        }
        else
        {
            line.startColor = Color.red;
            line.endColor = Color.red;
        }
        Vector3[] linePos = new Vector3[dragged.Count];
        line.positionCount = dragged.Count;
        for (int i = 0; i < dragged.Count; i++)
        {
            linePos[i] = dragged[i].transform.position;
        }
        line.SetPositions(linePos);
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
        //col.enabled = true;
    }

    public void addDragged(GameObject obj)
    {
        dragged.Add(obj);
    }

    public bool isDragging()
    {
        return dragging;
    }
}
