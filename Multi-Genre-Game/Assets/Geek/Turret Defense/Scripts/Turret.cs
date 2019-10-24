using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Camera cam;
    Vector3 Position = new Vector3();
    float myLeft = 0;
    float myTop = 0;
    float myWidth = 200;
    float myHeight = 50;


    bool isDragging = true;
    //a bool to show if it's curently active or not

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
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
        }

        if (isDragging)
        {
            Position = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Position.z = 1.0f;
            gameObject.transform.position = Position;
        }
    }

    //move the turret after it's been placed
    public void OnMouseDown()
    {
        isDragging = true;

    }
    //need a method to snap turret placement to grid
    //check if turret's placement is valid
    //if turret is not placed validly, move it back to where it was?
    //if turret is valid placement, now it can be put into play

    //then we can focus on what the turret does once it's placed
    
}
