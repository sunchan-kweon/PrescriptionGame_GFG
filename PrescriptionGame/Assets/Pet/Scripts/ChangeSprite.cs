using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public SpriteRenderer dog;
    public Sprite hungrysprite;
    public Sprite happysprite;
    public NeedsController n;

    // Start is called before the first frame update
    void Start()
    {
        dog.sprite = happysprite;
    }

    // Update is called once per frame
    void Update()
    {
        if( n.food >= 50)
        {
            dog.sprite = happysprite;
        }
        else
        {
            dog.sprite = hungrysprite;
        }
    }
}
