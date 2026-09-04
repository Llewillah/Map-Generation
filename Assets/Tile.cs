using UnityEngine;

public class Tile : MonoBehaviour
{
    int x, y;

    public void SetUp(int x, int y) 
    {
        this.x = x; this.y = y;
    }

    public void ChangeColour(Color colour) 
    { 
        GetComponent<SpriteRenderer>().color = colour;
    }
}
