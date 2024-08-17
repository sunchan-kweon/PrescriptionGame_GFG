using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PatientInfo
{
    public static int medId = 0;
    public static string medAmount;
    public static int[] matcherIds;
    public static List<int> medications = new List<int>();
    public static string time1;
    public static string time2;
    public static string petName;
    public static string dosage;
    public static string time;


    public static void setId(int id)
    {
        medId = id;
        matcherIds = new int[] { id, 7, 10, 4, 5};
    }

    public static void setMedAmount(string amount)
    {
        medAmount = amount;
    }

    public static void setMatcherIds(int[] ids)
    {
        matcherIds = ids;
    }

    public static int randomMed()
    {
        if (medications.Count != 0) 
        {
            return medications[Random.Range(0, PatientInfo.medications.Count)];
        }
        else
        {
            return 0;
        }
        
    }

    public static void setTime(string t)
    {
        time = t;
    }

    public static void addMedication(int id)
    {
        
        for(int i = 0; i < medications.Count; i++)
        {
            if (medications[i] == id)
            {
                medications.Remove(i);
            }
            else
            {
                medications.Add(id);
            }
        }
    }

    /*public static void setTime1(int t)
    {
        switch (t)
        {
            case 0:
                time1 = "Before Each Meal"; break;
            case 1:
                time1 = "After Each Meal"; break;
            case 2:
                time1 = "Before Breakfast"; break;
            case 3:
                time1 = "After Breakfast"; break;
            case 4:
                time1 = "Before Lunch"; break;
            case 5:
                time1 = "After Lunch"; break;
            case 6:
                time1 = "Before Dinner"; break;
            case 7:
                time1 = "After Dinner"; break;
            default:
                time1 = "None"; break;
        }
    }

    public static void setTime2(int t)
    {
        switch (t)
        {
            case 0:
                time2 = "Before Each Meal"; break;
            case 1:
                time2 = "After Each Meal"; break;
            case 2:
                time2 = "Before Breakfast"; break;
            case 3:
                time2 = "After Breakfast"; break;
            case 4:
                time2 = "Before Lunch"; break;
            case 5:
                time2 = "After Lunch"; break;
            case 6:
                time2 = "Before Dinner"; break;
            case 7:
                time2 = "After Dinner"; break;
            default:
                time2 = "None"; break;
        }
    }*/

}
