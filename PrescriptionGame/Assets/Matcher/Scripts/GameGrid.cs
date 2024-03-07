using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    //Replace Object with Berry Class
    [SerializeField] BerryHolder holder;
    [SerializeField] BerryMover mover;
    GameObject[,] board;
    public int width;
    public int height;
    public GameGrid(int w, int h)
    {
        //Initialize the Board with size width, height. Height is at the bottom 0 is at the top.
        board = new GameObject[width, height];
        width = w;
        height = h;
    }

    private void Start()
    {
        //INITIAL SETUP FOR BOARD SIZE AND FILLING
        setWidth(9);
        setHeight(9);
        board = new GameObject[width, height];
        fillBoard(new int[] {0, 0});
    }

    void fillBoard(int[] ids)
    {
        for(int x = 0; x < width; x++)
        {
            for (int y = height - 1; y >= 0; y--)
            {
                if (board[x, y] == null)
                {
                    board[x, y] = Instantiate(holder.getBerry(ids[Random.Range(0, ids.Length)]), new Vector3(50, 0f, 50), Quaternion.identity);
                }
            }
        }
        mover.updateBoard();
    }


    void gravity()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = height - 1; y >= 0; y--)
            {
                if (board[x, y] == null)
                {
                    
                }
            }
        }
    }

    GameObject remove(int x, int y)
    {
        //Remove berry from list and return what was removed
        GameObject removed = board[x, y];
        board[x, y] = null;
        return removed;
    }

    //Loc is an array that contains the x and y position on the board of which to be removed
    GameObject[] removedDir(int[,] loc)
    {
        GameObject[] removed = new GameObject[loc.GetLength(0) + 1];
        for(int i = 0; i < loc.GetLength(0); i++)
        {
            removed[i] = remove(loc[i, 0], loc[i, 1]);
        }
        return removed;

    }

    public int getWidth()
    {
        return width;
    }

    public int getHeight()
    {
        return height;
    }

    public void setHeight(int h)
    {
        height = h;
    }

    public void setWidth(int w)
    {
        width = w;
    }

    public GameObject get(int x, int y)
    {
        return board[x, y];
    }
    
}
