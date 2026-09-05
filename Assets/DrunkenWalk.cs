using UnityEngine;

public class DrunkenWalk : MonoBehaviour
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

    public void TakeStep() 
    {
        //pick a random starting tile
        int curX = Random.Range(0, grid.width);
        int curY = Random.Range(0, grid.height);
        
        int curTiles = 0;

        Tile cur;

        while (curTiles < totalTiles) 
        {
            //get the current tile
            cur = grid.GetTile(curX,curY);


            //if still wall convert it to floor
            if(!cur.visited) 
            {
                cur.visited = true;
                cur.ChangeColour(Color.white);
                curTiles++;
            }
            
            //pick a random direction
            int randInt = Random.Range(0, 4);

            curX += dirs[randInt].x;
            curY += dirs[randInt].y;


            //bind the x and the y to the size of the grid
            if (curX >= grid.width)
            {
                curX--;
            }
            else if (curX < 0) 
            {
                curX++;
            }

            if (curY >= grid.height)
            {
                curY--;
            }
            else if (curY < 0)
            {
                curY++;
            }
        }   
    }
}
