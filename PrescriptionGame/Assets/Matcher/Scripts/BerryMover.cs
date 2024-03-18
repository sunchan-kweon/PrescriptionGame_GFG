using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryMover : MonoBehaviour
{

    [SerializeField] GameGrid grid;
    [SerializeField] float xScale;
    [SerializeField] float yScale;
    [SerializeField] float xOffset;
    [SerializeField] float yOffset;
    [SerializeField] float berryScale;



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

    public float getScale()
    {
        return berryScale;
    }

    //Converts X from matrix to real space
    float conX(int x)
    {
        return x*xScale + xOffset;
    }
    //Same for Y
    float conY(int y)
    {
        return y*yScale + yOffset;
    }

}
