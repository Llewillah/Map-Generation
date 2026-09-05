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
        int curX = Random.Range(0, grid.width);
        int curY = Random.Range(0, grid.height);

        int curTiles = 0;

        Stack<Tile> stack = new Stack<Tile>();
        stack.Push(grid.GetTile(curX, curY));
        Tile cur;

        while (curTiles < totalTiles) 
        {
            cur = stack.Pop();
        }
    }
}
