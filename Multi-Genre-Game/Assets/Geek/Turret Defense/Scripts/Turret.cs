using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Camera cam;
    public Grid grid;
    public GameObject bullet;
    Vector3 Position = new Vector3();
    float myLeft = 0;
    float myTop = 0;
    float myWidth = 200;
    float myHeight = 50;

    int counter;//this will be replaced with a timer


    bool isDragging = true;
    bool placeable = true;
    bool isPlaced = false;
    //a bool to show if it's curently active or not

    // Start is called before the first frame update
    void Start()
    {
        counter = 60;
        cam = Camera.main;
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        Position = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Position.z = 1.0f;
        gameObject.transform.position = Position;
        Debug.Log("pos: "+gameObject.transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            if (placeable==true)
                SnapToGrid();
            else Debug.Log("This tile is occupied!");
        }

        if (isDragging)
        {
            Position = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Position.z = 1.0f;
            gameObject.transform.position = Position;
        }

        if (isPlaced)
        {
            //add stuff here for what the turret should do while it is active!
            //add a radius of detection for stuff
            //make it spawn a projectile
            //something like that
            if (counter == 60)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                counter = 0;
            }
            else
                counter++;
        }
    }

    //move the turret after it's been placed
    public void OnMouseDown()
    {
        if(isPlaced)
            isDragging = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        placeable = false;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        placeable = true;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
    }
    //need a method to snap turret placement to grid
    //check if turret's placement is valid
    //if turret is not placed validly, move it back to where it was?
    //if turret is valid placement, now it can be put into play

    /// <summary>
    /// This method causes the game object to snap to the 
    /// </summary>
    public void SnapToGrid()
    {
        gameObject.transform.position = grid.GetCellCenterWorld(grid.WorldToCell(Position));
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        isPlaced = true;
    }
    //then we can focus on what the turret does once it's placed
    
}
