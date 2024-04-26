using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Result : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI corncounttext;
    public TextMeshProUGUI flourcounttext;
    public TextMeshProUGUI metformincounttext;
    public TextMeshProUGUI insulincounttext;

    public int cornresult;
    public int flourresult;
    public int metforminresult;
    public int insulinresult;
    public int caffeineresult;

    // Start is called before the first frame update
    void Start()
    {

        caffeineresult = DragBehavior.caffeinecount / 6;
        insulinresult = DragBehavior.insulincount / 9;
        metforminresult = DragBehavior.metformincount / 9;
        cornresult = DragBehavior.corncount / 9;
        flourresult = DragBehavior.corncount / 9;

        scoretext.text = GameGrid.score.ToString("D6");

        Inventory.caffeine += caffeineresult;
        Inventory.insulin += insulinresult;
        Inventory.metformin += metforminresult;
        Inventory.corn += cornresult;
        Inventory.flour += flourresult;

        Debug.Log(cornresult);
        Debug.Log(flourresult);
        Debug.Log(metforminresult);
        Debug.Log(insulinresult);
        Debug.Log(caffeineresult);

        corncounttext.text = cornresult.ToString("D2");
        flourcounttext.text = flourresult.ToString("D2");
        metformincounttext.text = metforminresult.ToString("D2");
        insulincounttext.text = insulinresult.ToString("D2");

        SaveSystem.SavePet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
