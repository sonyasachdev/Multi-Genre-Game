using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //feilds for tile

    //is the tile currently occupied by an object?
    bool Occupied;
    //by what object(reference)?
    //is the tile part of a path?
    public bool Path=false;
    //what's the next tile(s) in the path?
    public GameObject nextTile = null;

    
    // Start is called before the first frame update
    //start is called at the start of the level ,so the grid manager will hold and assign all paths
    //by default the next tile is null, so there's no path
    //if it assigns a gameobject, then that's the next tile in the path
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
