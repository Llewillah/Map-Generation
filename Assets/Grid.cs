using Unity.VisualScripting;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int width, height;
    public float cellSize;
    public Vector2 startPos;
    public GameObject tile;


    Tile[,] grid;

    private void Start()
    {
        grid = new Tile[width, height];

        for (int x = 0; x < width; x++) 
        {
            for (int y = 0; y < height; y++)
            {
                grid[x, y] = SpawnTile(GetWorldPos(x, y));
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
}
