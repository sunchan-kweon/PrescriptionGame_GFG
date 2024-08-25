using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    public static int progressionCounter;
    public BerryHolder holder;
    public SetLanguageText progressionText;
    public GameObject progressionPanel1;
    public GameObject progressionPanel2;
    public GameObject progressionPanel3;
    public GameObject progressionPanel4;
    public int[] getProgression()
    {
        if(progressionCounter <= 0)
        {
            progressionPanel1.SetActive(true);
            return new int[] { PatientInfo.randomMed(), 4 };
        }
        else if(progressionCounter <= 1)
        {
            progressionPanel2.SetActive(true);
            return new int[] { PatientInfo.randomMed(), 4, 5 };
        }
        else if(progressionCounter <= 2)
        {
            progressionPanel3.SetActive(true);
            return new int[] { PatientInfo.randomMed(), 4, 5, 3 };
        }
        else if(progressionCounter <= 3)
        {
            progressionPanel4.SetActive(true);
            return new int[] { PatientInfo.randomMed(), 10, 3};
        }
        else
        {
            return new int[] { PatientInfo.randomMed(), getIncrease(), getDecrease(), getNeutral()};
        }
    }

    private int getIncrease()
    {
        List<int> increases = new List<int>();
        for(int i = 0; i < holder.getSize(); i++)
        {
            if (holder.getBerry(i).GetComponent<Berry>().bloodAmount > 0 || holder.getBerry(i).GetComponent<Berry>().getTags()[0].Equals("Food"))
            {
                increases.Add(holder.getBerry(i).GetComponent<Berry>().getId());
            }
        }
        return increases[Random.Range(0, increases.Count)];
    }

    private int getDecrease()
    {
        List<int> decreases = new List<int>();
        for (int i = 0; i < holder.getSize(); i++)
        {
            if (holder.getBerry(i).GetComponent<Berry>().bloodAmount < 0 || holder.getBerry(i).GetComponent<Berry>().getTags()[0].Equals("Food"))
            {
                decreases.Add(holder.getBerry(i).GetComponent<Berry>().getId());
            }
        }
        return decreases[Random.Range(0, decreases.Count)];
    }

    private int getNeutral()
    {
        List<int> neutrals = new List<int>();
        for (int i = 0; i < holder.getSize(); i++)
        {
            if (holder.getBerry(i).GetComponent<Berry>().bloodAmount == 0 || holder.getBerry(i).GetComponent<Berry>().getTags()[0].Equals("Food"))
            {
                neutrals.Add(holder.getBerry(i).GetComponent<Berry>().getId());
            }
        }
        return neutrals[Random.Range(0, neutrals.Count)];
    }

}
