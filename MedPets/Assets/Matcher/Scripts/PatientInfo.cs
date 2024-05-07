using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PatientInfo
{
    public static int medId;
    public static string medAmount;
    public static int[] matcherIds;
    public static string time1;
    public static string time2;


    public static void setId(int id)
    {
        medId = id;
        matcherIds = new int[] { id, 2, 3};
    }

    public static void setMedAmount(string amount)
    {
        medAmount = amount;
    }

    public static void setMatcherIds(int[] ids)
    {
        matcherIds = ids;
    }

    public static void setTime1(int t)
    {
        switch (t)
        {
            case 0:
                time1 = "Antes de la comida"; break;
            case 1:
                time1 = "Después de la comida"; break;
            case 2:
                time1 = "Antes del desayuno"; break;
            case 3:
                time1 = "Después del desayuno"; break;
            case 4:
                time1 = "Antes del almuerzo"; break;
            case 5:
                time1 = "Después del almuerzo"; break;
            case 6:
                time1 = "Antes de la cena"; break;
            case 7:
                time1 = "Después de la cena"; break;
            default:
                time1 = "None"; break;
        }
    }

    public static void setTime2(int t)
    {
        switch (t)
        {
            case 0:
                time2 = "Antes de la comida"; break;
            case 1:
                time2 = "Después de la comida"; break;
            case 2:
                time2 = "Antes del desayuno"; break;
            case 3:
                time2 = "Después del desayuno"; break;
            case 4:
                time2 = "Antes del almuerzo"; break;
            case 5:
                time2 = "Después del almuerzo"; break;
            case 6:
                time2 = "Antes de la cena"; break;
            case 7:
                time2 = "Después de la cena"; break;
            default:
                time2 = "None"; break;
        }
    }

}
