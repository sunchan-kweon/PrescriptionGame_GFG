using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tutorial : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject parent;
    public RectTransform rect;
    public float speed;

    public int[] progression;

    public string[,] text;
    public int language;
    private int currentText;

    private int currentPanel;
    private int lastPanel;
    private float currentLoc;
    public int spacing = 800;

    private void Start()
    {
        lastPanel = 0;
        currentLoc = 0;
        text = new string[1, 100];
        for(int i = 0; i < 100; i++)
        {
            text[0, i] = "Test";
        }
        for(int i = 0; i < progression.Length; i++)
        {
            GameObject current = Instantiate(prefabs[progression[i]], parent.transform);
            current.GetComponent<TextChanger>().text = text[language, currentText];
            currentText++;
            if (current.GetComponent<TextChanger>().hasMultiple)
            {
                current.GetComponent<TextChanger>().text2 = text[language, currentText];
                currentText++;
            }
        }
    }

    private void Update()
    {
        if(currentLoc != rect.localPosition.x)
        {
            int direction = (rect.localPosition.x < currentLoc) ? 1 : -1;
            rect.localPosition = new Vector2(rect.localPosition.x + (speed * direction), rect.localPosition.y);
            if(currentLoc > rect.localPosition.x - speed + 1 && currentLoc < rect.localPosition.x + speed + 1)
            {
                rect.localPosition = new Vector2(currentLoc, rect.localPosition.y);
            }
        }
    }

    private void Move()
    {
        if(currentPanel != 0)
        {
            int direction = (currentPanel > lastPanel) ? 1 : -1;
            if (progression[currentPanel] > 2 || progression[lastPanel] > 2)
            {
                currentLoc = currentLoc + (spacing * direction);
            }
            else
            {
                currentLoc = currentLoc + (spacing * direction);
                rect.localPosition = new Vector2(currentLoc, rect.localPosition.y);
            }
        }
        else
        {
            int direction = (currentPanel > lastPanel) ? 1 : -1;
            rect.localPosition = new Vector2(rect.localPosition.x + (spacing * direction), rect.localPosition.y);
            currentLoc = 0;
        }
    }

    public void MoveLeft()
    {
        if (currentPanel != 0)
        {
            lastPanel = currentPanel;
            currentPanel -= 1;
            Move();
        }
        Debug.Log(currentLoc + " " + currentPanel + " " + lastPanel);
    }

    public void MoveRight()
    {
        Debug.Log(transform.childCount);
        if(currentPanel != transform.childCount)
        {
            lastPanel = currentPanel;
            currentPanel += 1;
            Move();
        }
        Debug.Log(currentLoc + " " + currentPanel + " " + lastPanel);
    }
}
