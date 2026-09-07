using System.Collections.Generic;
using UnityEngine;

public class RandomisedDepthFirstSearch : MonoBehaviour
{
    Grid grid;

    public void SetUp(Grid grid)
    {
        this.grid = grid;
    }

    public void StartGen() 
    { 
        Stack<Tile> stack = new Stack<Tile>();

        //pick first tile
        int randX = Random.Range(0, grid.width);
        int randY = Random.Range(0, grid.height);

        stack.Push(grid.GetTile(randX, randY));


        while (stack.Count > 0)
        {
            //Pop tile from top of stack
            Tile cur = stack.Pop();
            cur.visited = true;
            cur.ChangeColour(Color.white);

            //Check all neighbours for unvisited tiles
            List<Tile> neighbours = new List<Tile>();

            if (cur.x - 2 >= 0 && !grid.GetTile(cur.x - 2, cur.y).visited) 
            {
                neighbours.Add(grid.GetTile(cur.x - 2, cur.y));
            }

            if (cur.x + 2 < grid.width && !grid.GetTile(cur.x + 2, cur.y).visited) 
            {
                neighbours.Add(grid.GetTile(cur.x + 2, cur.y));
            }

            if (cur.y - 2 >= 0 && !grid.GetTile(cur.x, cur.y - 2).visited)
            {
                neighbours.Add(grid.GetTile(cur.x, cur.y - 2));
            }

            if (cur.y + 2 < grid.height && !grid.GetTile(cur.x, cur.y + 2).visited)
            {
                neighbours.Add(grid.GetTile(cur.x, cur.y + 2));
            }
            //pick random univisted tile and add to stack
            if (neighbours.Count > 0) 
            { 
                int rand = Random.Range(0, neighbours.Count);

                stack.Push(cur);
                stack.Push(neighbours[rand]);
                
                //change wall between tiles to floor
                int difX = neighbours[rand].x - cur.x;
                int difY = neighbours[rand].y - cur.y;

                Tile wall = grid.GetTile(cur.x + WorkingSign(difX), cur.y + WorkingSign(difY));
                wall.ChangeColour(Color.white);
            }

        }
    }

    //Unity's doest return 0 for 0 
    int WorkingSign(int i) 
    {
        if (i > 0)
        {
            return 1;
        }
        else if (i < 0)
        {
            return -1;
        }
        else 
        {
            return 0;
        }
    }
}
