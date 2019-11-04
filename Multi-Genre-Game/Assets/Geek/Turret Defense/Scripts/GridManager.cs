using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    //the height of the grid by #tiles
    public static int Height = 10;
    //the width of the grid by #tiles
    public static int Width = 15;
    //the position of the tile in the upper left corner
    public Vector2 UpLeftCornerTilePos = new Vector2(-9.5f, 4.5f); //-9.5, 4.5
    //the h and w of individual tiles
    public float TileSize = 1.0f;
    //the distance of any gap between tiles
    public float TileGap = 0.0f;

    //contains a list/dictionary, or other which has references to all tile objects
    //a reference to the tile prefab
    public GameObject TilePrefab;
    //a 2d array, aka a matrix which stores all our tiles
    public GameObject[,] Grid;
    //start with one path, we can add the capability for more later. the path is basically an array. but paths are also stored in tile objects
    public List<Vector2> Path = new List<Vector2> { };
    

    //a reference to the tile(s) where the portal/ nerd is

    // Start is called before the first frame update
    void Start()
    {
        //create all the tile peices from the initial peice
        //vector 2: the position of the tile we're initializing
        Vector2 currentPos = UpLeftCornerTilePos;
        float tiledist = TileSize + TileGap; //the distance from center of tile to center of tile
        Grid = new GameObject[Width,Height];
        //for loop through each column
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++) //go down each collumn and add tiles
            {
                GameObject tile =Instantiate(TilePrefab); // make a new instance of the prefab
                tile.transform.position = currentPos; //set the position
                tile.transform.SetParent(gameObject.transform);//make it's parent the grid manager, jsut to keep things tidy
                
                Grid[i,j] = tile; //put it in the grid list
                
                //iterate the row
                currentPos.y = UpLeftCornerTilePos.y - (tiledist * j);
            }
            //iterate the column
            currentPos.x = UpLeftCornerTilePos.x + (tiledist * i);
        }

        for (int k = 0; k < Width; k++)
        {
           
            Path.Add(new Vector2(k,5));
            
            Grid[k, 5].GetComponent<Tile>().Path = true;
            Grid[k, 5].GetComponent<SpriteRenderer>().color = Color.white;
            //FFFFFF
        }
        for (int i = 0; i < Width; i++)
        {
            print(i);
            if (i == (Width-1))
            {
               
                Grid[(int)Path[i].x, (int)Path[i].y].GetComponent<Tile>().nextTile = this.gameObject; // set the final tile in the path's next tile to be the tile manager. so we can check it
            }
            else
            {
                Grid[(int)Path[i].x, (int)Path[i].y].GetComponent<Tile>().nextTile = Grid[(int)Path[i + 1].x, (int)Path[i + 1].y];//set the next tile to the next tile
            }
            
        }

        //assign the path



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
