using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuidebookItem : MonoBehaviour
{
    public int guidebookID;

    public void setGuidebookID(int id)
    {
        GuidebookInfo.guidebookID = guidebookID;
    }
}
