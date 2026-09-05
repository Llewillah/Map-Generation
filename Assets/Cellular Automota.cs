using UnityEngine;

public class CellularAutomota : MonoBehaviour
{
    public int threshold = 4, numPass = 4;
    public float floorChance = 0.5f;
    Grid grid;

    public void SetUp(Grid grid)
    {
        this.grid = grid;
    }

    public void StartGen() 
    {
        //pass over grid setting random tiles as floors
        foreach (Tile t in grid.grid)
        {
            float rand = Random.Range(0, 1f);

            if (rand < floorChance)
            {
                t.ChangeColour(Color.white);
                t.visited = true;
            }
        }

        //update the map based on num times set to
        for (int i = 0; i < numPass; i++) 
        {
            UpdateMap();
        }
    }


    void UpdateMap()
    {
        //create a new grid to store neighbour results
        bool[,] newGrid = new bool[grid.width, grid.height];

        for (int x = 0; x < grid.width; x++) 
        {
            for (int y = 0; y < grid.height; y++) 
            {
                //check each neighbour of a tile
                newGrid[x,y] = CheckNeighbours(x, y);
            }
        }

        //applys the updated results to the original grid
        for (int x = 0; x < grid.width; x++)
        {
            for (int y = 0; y < grid.height; y++)
            {
                grid.GetTile(x, y).visited = newGrid[x, y];

                if (grid.GetTile(x, y).visited)
                {
                    grid.GetTile(x, y).ChangeColour(Color.white);
                }
                else 
                {
                    grid.GetTile(x, y).ChangeColour(Color.black);
                }
            }
        }
    }

    bool CheckNeighbours(int x, int y) 
    {
        int count = 0;
        //loops through all neighbours
        for (int a = -1; a < 2; a++)
        {
            for (int b = -1; b < 2; b++)
            {
                //ensures neighbour is within grid range
                if (x + a >= 0 && x + a < grid.width && y + b >= 0 && y + b < grid.height)
                {
                    if (grid.GetTile(x + a, y + b).visited) 
                    {
                        count++;
                    }
                }
            }
        }

        return count >= threshold;
    }
}
