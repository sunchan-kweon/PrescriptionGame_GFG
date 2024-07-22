using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragBehavior : MonoBehaviour
{
    public AudioClip rightaudio;
    public AudioClip wrongaudio;
    private AudioSource audioSource;

    
    public static int caffeinecount;
    public static int insulincount;
    public static int metformincount;
    public static int corncount;
    public static int flourcount;

    public Color correct;
    public Color wrong;

    //This script is on a collider that follows the mouse/finger when that is an option
    [SerializeField]List<GameObject> dragged = new List<GameObject> ();
    bool dragging = false;
    [SerializeField] GameGrid grid;
    [SerializeField] BerryMover mover;
    [SerializeField] BerryHolder holder;
    [SerializeField] CircleCollider2D col;
    [SerializeField] LineRenderer line;
    Vector3 mouseWorldPos;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Debug.Log("Caffeine count is: " + caffeinecount);
        Debug.Log("Insulin count is: " + insulincount);
        Debug.Log("Metformin count is: " + metformincount);
        Debug.Log("Corn count is: " + corncount);
        Debug.Log("Flour count is: " + flourcount);
        
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

    private int checkList()
    {
        if(dragged.Count > 0)
        {
            int prevId = dragged[0].GetComponent<Berry>().getId();
            int count = 0;
            int toMatch = dragged[0].GetComponent<Berry>().getNum2Match();
            int[] ids = new int[holder.getSize()];
            int chains = 1;
            List<string> tagsFound = new List<string>();
            for (int k = 0; k < dragged[0].GetComponent<Berry>().getTags().Length; k++)
            {
                tagsFound.Add(dragged[0].GetComponent<Berry>().getTags()[k]);
            }

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
                        for(int k = 0; k < dragged[i].GetComponent<Berry>().getTags().Length; k++)
                        {
                            tagsFound.Add(dragged[i].GetComponent<Berry>().getTags()[k]);
                        }
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
            //Tag Handling
            //Each in List Dragged
            for(int i = 0; i < dragged.Count; i++)
            {
                if(dragged[i].GetComponent<Berry>().getRequiredTags().Length > 0)
                {
                    //Each of the Required Tags
                    for (int j = 0; j < dragged[i].GetComponent<Berry>().getRequiredTags().Length; j++)
                    {
                        bool found = false;
                        //Each of the tags found
                        for (int k = 0; k < tagsFound.Count; k++)
                        {
                            if (dragged[i].GetComponent<Berry>().getRequiredTags()[j].Equals(tagsFound[k]))
                            {
                                found = true;
                                break;
                            }
                        }
                        if (found == false)
                        {
                            return -1;
                        }
                    }
                }
            }
            if(chains < 2)
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
                int clearid = dragged[i].GetComponent<Berry>().getId();
                switch(clearid){
                    case 0:
                        insulincount += 1;
                        break;
                    case 1:
                        metformincount += 1;
                        break;
                    case 2:
                        corncount += 1;
                        break;
                    case 3:
                        flourcount += 1;
                        break;
                    default:
                        break;
                }
            }
            clearAdded();
            audioSource.clip = rightaudio;
            audioSource.Play();
            grid.addScore(dragged.Count * 100);
            grid.removeGroup(loc); //Make variable later for inventory
            dragged.Clear();
        }
        else
        {
            clearAdded();
            audioSource.clip = wrongaudio;
            audioSource.Play();
            dragged.Clear();
        }
        line.positionCount = 0;
        clearAdded();
    }

    public void drawLines()
    {
        if(checkList() >= 0)
        {
            line.startColor = correct;
            line.endColor = correct;
        }
        else
        {
            line.startColor = wrong;
            line.endColor = wrong;
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
            dragged[i].GetComponent<Berry>().setAdded(false);
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
