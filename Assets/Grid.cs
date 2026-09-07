using UnityEngine;

public class Grid : MonoBehaviour
{
    public int width, height;
    public float cellSize;
    public Vector2 startPos;
    public GameObject tile;


    public Tile[,] grid;

    private void Start()
    {
        grid = new Tile[width, height];

        for (int x = 0; x < width; x++) 
        {
            for (int y = 0; y < height; y++)
            {
                grid[x, y] = SpawnTile(GetWorldPos(x, y));
                grid[x, y].SetUp(x, y);
            }
        }
    }

    Tile SpawnTile(Vector2 pos) 
    {
        return Instantiate(tile, pos, Quaternion.identity).GetComponent<Tile>();
    }

    Vector2 GetWorldPos(int x, int y) 
    {
        return new Vector2(startPos.x + x * cellSize, startPos.y + y * cellSize);
    }

    public void ResetGrid() 
    {
        foreach (Tile t in grid) 
        {
            t.ChangeColour(Color.black);
            t.visited = false;
        }
    }
    public Tile GetTile(int x, int y) 
    {
        return grid[x, y];
    }

    public bool GetVisited(int x, int y) 
    {
        if (x < 0 || x >= width || y < 0 || y >= height) 
        {
            return true;
        }

        return grid[x, y].visited;
    }
}
