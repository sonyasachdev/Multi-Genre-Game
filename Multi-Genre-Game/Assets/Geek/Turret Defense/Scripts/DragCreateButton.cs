using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class DragCreateButton : MonoBehaviour
{
    public GameObject Item;

    float myLeft = 0;
    float myTop = 0;
    float myWidth = 200;
    float myHeight = 50;


    bool isDragging = false;


    

    void Update()
    {
        //print(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
            isDragging = false;

    }

    public void OnMouseDown()
    {
        Debug.Log("button clicked");
        Instantiate(Item);
        //create a new turret

    }
}

   