using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.IO.Hashing;
public class Room 
{ 
    //room bounds
    public int x1,y1,x2,y2, width, height;
    public Room lRoom, rRoom;

    public Room(int x1, int y1, int x2, int y2) 
    { 
        this.x1 = x1; this.y1 = y1;
        this.x2 = x2; this.y2 = y2;

        width = x2 - x1;
        height = y2 - y1;
    }

    public void UpdateBounds()
    {
        width = x2 - x1;
        height = y2 - y1;
    }

    public bool isLeaf() 
    {
        return (lRoom == null) && (rRoom == null);
    }
}

public class BinarySpacePartitioning : MonoBehaviour
{
    public int minWidth, minHeight, maxTrim;
    Grid grid;
    Room root;
    public bool dungeon = false;
    public bool viewPath = true;

    public void SetUp(Grid grid) 
    {
        this.grid = grid;
    }

    public void StartGen() 
    {
        root = new Room(0, 0, grid.width - 1, grid.height - 1);
        CutRectangle(root);

        if (dungeon)
        {
            TrimRoom(root);
        }
        else 
        {
            AddBorder(root);
        }
        DisplayRooms(root);
        DrawPaths(root);
    }

    void CutRectangle(Room room) 
    {
        //pick random split
        int rand = Random.Range(0, 2);

        //check if one split cant be completed where the other can
        if (room.width <= minWidth * 2 && room.height > minHeight * 2)
        {
            rand = 1;
        }
        else if (room.width > minWidth * 2 && room.height <= minHeight * 2) 
        {
            rand = 0;
        }

        //horizontal split
        if (room.width > minWidth * 2 && rand == 0)
        {
            //pick a random amount to split by
            int split = Random.Range(minWidth, room.width - minWidth);

            //get the new room bounds
            room.lRoom = new Room(room.x1, room.y1, room.x1 + split, room.y2);
            room.rRoom = new Room(room.x1 + split, room.y1, room.x2, room.y2);

            //Repeat process on new rooms
            CutRectangle(room.lRoom);
            CutRectangle(room.rRoom);
        }
        //vertical split
        else if (room.height > minHeight * 2 && rand == 1) 
        {
            //pick a random amount to split by
            int split = Random.Range(minHeight, room.height - minHeight);

            //get the new room bounds
            Room newRoom = new Room(room.x1, room.y1 + split, room.x2, room.y2);
            room.lRoom = new Room(room.x1, room.y1, room.x2, room.y1 + split);
            room.rRoom = new Room(room.x1, room.y1 + split, room.x2, room.y2);

            //Repeat process on new rooms
            CutRectangle(room.lRoom);
            CutRectangle(room.rRoom);
        }
    }

    void TrimRoom(Room room) 
    {
        if (room.isLeaf())
        {
            int xTrim = Random.Range(1, maxTrim + 1);
            int yTrim = Random.Range(1, maxTrim + 1 - xTrim);

            for (int i = 0; i < xTrim; i++)
            {
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    room.x1++;
                }
                else
                {
                    room.x2--;
                }
            }

            for (int i = 0; i < yTrim; i++)
            {
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    room.y1++;
                }
                else
                {
                    room.y2--;
                }
            }

            room.UpdateBounds();
        }
        else 
        {
            TrimRoom(room.lRoom);
            TrimRoom(room.rRoom);
        }
    }

    void DisplayRooms(Room room) 
    {
        //check if at bottom of the tree
        if (room.isLeaf())
        {

            //draw the area of the room
            for (int x = room.x1; x < room.x2; x++)
            {
                for (int y = room.y1; y < room.y2; y++)
                {
                    grid.GetTile(x, y).ChangeColour(Color.white);
                }
            }
        }
        else 
        {
            //check the next layer of rooms
            DisplayRooms(room.lRoom);
            DisplayRooms(room.rRoom);
        }
    }

    void DrawPaths(Room room) 
    {
        //check if at bottom of tree
        if (!room.isLeaf()) 
        {
            //find the centre for the two rooms
            int x1 = room.lRoom.x1 + room.lRoom.width / 2;
            int y1 = room.lRoom.y1 + room.lRoom.height / 2;

            int x2 = room.rRoom.x1 + room.rRoom.width / 2;
            int y2 = room.rRoom.y1 + room.rRoom.height / 2;


            //Draw a line between the rooms
            Color pathCol = (viewPath) ? Color.red : Color.white;

            for (int x = x1; x < x2; x++) 
            {
                grid.GetTile(x, y1).ChangeColour(pathCol);
            }

            for (int y = y1; y < y2; y++) 
            {
                grid.GetTile(x1, y).ChangeColour(pathCol);
            }
            //Check the next layer of rooms

            DrawPaths(room.lRoom);
            DrawPaths(room.rRoom);
        }
    }

    void AddBorder(Room room) 
    {
        if (room.isLeaf())
        {
            room.x1++;
            room.y1++;
        }
        else 
        { 
            AddBorder(room.lRoom);
            AddBorder(room.rRoom);
        }
    }
}
