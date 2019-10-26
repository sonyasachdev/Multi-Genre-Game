using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Movement Speed of Character
    public float moveSpeed = 5f;
    //Drag the Rigidbody in
    public Rigidbody2D rb;
    //Camera Variable
    public Camera cam;
    //Movement
    Vector2 movement;
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        //Input
        //Unity's Method that takes in Input data and helps determine which direction the player is moving
        //This accepts arrow keys & wasd
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        //Moves character
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //Has Character's Angle Face Mouse
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
