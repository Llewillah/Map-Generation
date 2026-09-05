using UnityEngine;

public class Tile : MonoBehaviour
{
    public int x, y;
    public bool visited = false;

    public void SetUp(int x, int y) 
    {
        this.x = x; this.y = y;
    }

    public void ChangeColour(Color colour) 
    { 
        GetComponent<SpriteRenderer>().color = colour;
    }
}
