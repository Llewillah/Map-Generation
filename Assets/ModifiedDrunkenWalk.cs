using UnityEngine;
using System.Collections.Generic;

public class ModifiedDrunkenWalk : MonoBehaviour
{
    public float percentCoverage;
    Vector2Int[] dirs = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
    Grid grid;
    int totalTiles;

    public void SetUp(Grid grid)
    {
        this.grid = grid;
        totalTiles = (int)(grid.width * grid.height * (percentCoverage / 100));
    }

    public void DoGen() 
    {
        //pick a random starting tile
        int curX = Random.Range(0, grid.width);
        int curY = Random.Range(0, grid.height);

        int curTiles = 0;

        Stack<Tile> stack = new Stack<Tile>();

        //handle the first tile
        Tile cur = grid.GetTile(curX, curY);
        cur.visited = true;
        cur.ChangeColour(Color.white);
        curTiles++;
        stack.Push(cur);
        
        while (curTiles < totalTiles) 
        {
            cur = stack.Pop();
            List<Tile> neighbours = new List<Tile>();
            

            //check if neghbours have been visited
            foreach (Vector2Int dir in dirs) 
            {
                if (!grid.GetVisited(cur.x + dir.x, cur.y + dir.y)) 
                {
                    neighbours.Add(grid.GetTile(cur.x + dir.x, cur.y + dir.y));
                }
            }

            //if any unvisited neghbours, remove wall and add it to the stack
            if (neighbours.Count > 0)
            {
                int randInt = Random.Range(0, neighbours.Count);

                stack.Push(cur);
                stack.Push(neighbours[randInt]);
                neighbours[randInt].visited = true;
                neighbours[randInt].ChangeColour(Color.white);
                curTiles++;
            }
        }
    }
}
