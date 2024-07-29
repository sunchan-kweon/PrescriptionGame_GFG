using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public Animator anim;

    public void scrollOut()
    {
        anim.SetBool("isIn", false);
    }

    public void scrollIn()
    {
        anim.SetBool("isIn", true);
    }
}
