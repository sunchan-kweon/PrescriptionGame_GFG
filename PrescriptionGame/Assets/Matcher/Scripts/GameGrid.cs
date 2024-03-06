using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    //Replace Object with Berry Class
    [SerializeField] BerryHolder holder;
    Berry[,] board;
    int width;
    int height;
    public GameGrid(int w, int h)
    {
        //Initialize the Board with size width, height.
        board = new Berry[width, height];
        width = w;
        height = h;
    }

    void fillBoard(int[] ids)
    {
        //Future Use
        for(int x = 0; x < width; x++)
        {
            for (int y = height - 1; y >= 0; y--)
            {
                board[x, y] = holder.getBerry(ids[Random.Range(0, ids.Length)]);
            }
        }
    }

    void gravity()
    {
        //Future "Gravity" for berries
    }

    Object remove(int x, int y)
    {
        //Remove berry from list
        return null;
    }


    
}
