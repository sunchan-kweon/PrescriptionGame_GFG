using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryMover : MonoBehaviour
{

    [SerializeField] GameGrid grid;

    
    public void updateBoard()
    {
        for(int x = 0; x < grid.getWidth(); x++)
        {
            for (int y = grid.getHeight() - 1; y >= 0; y--)
            {
                if(grid.get(x,y) != null)
                {
                    GameObject current = grid.get(x, y);
                    if (current.transform.position.x != conX(x) || current.transform.position.y != conY(y))
                    {
                        current.transform.position = new Vector3(conX(x), conY(y), 0);
                    }
                }
            }
        }

    }

    //Converts X from matrix to real space
    int conX(int x)
    {
        return x;
    }
    //Same for Y
    int conY(int y)
    {
        return y;
    }

}
