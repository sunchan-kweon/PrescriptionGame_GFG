using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuidebookFiller : MonoBehaviour
{
    public BerryHolder holder;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < holder.getSize(); i++)
        {
            if (holder.getBerry(i).GetComponent<Berry>().getTags()[0].Equals("Medication"))
            {
                GameObject current = Instantiate(prefab, transform);
                current.transform.GetChild(0).GetComponentInChildren<Image>().sprite = holder.getBerry(i).GetComponent<Image>().sprite;
                current.GetComponentInChildren<GuidebookItem>().guidebookID = i;
            }
        }
    }
}
