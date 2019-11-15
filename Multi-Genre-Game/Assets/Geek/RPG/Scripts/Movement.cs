using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Movement Speed of Character
    private float moveSpeed = 5f;
    //Drag the Rigidbody in
    public Rigidbody2D rb;
    //Camera Variable
    public Camera cam;
    //Movement
    public static Vector2 movement;
    private float horizontalMovement;
    private float verticalMovement;

    public static Vector3 lookDir;
    public Transform firePoint;

    enum direction { Up, Down, Left, Right};
    direction playerDirection;

    private void Start()
    {
        playerDirection = direction.Up;
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        //Unity's Method that takes in Input data and helps determine which direction the player is moving
        //This accepts arrow keys & wasd and uses raw input        
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        Debug.Log(transform.rotation.eulerAngles.z);
    }

    void FixedUpdate()
    {
        //Makes sure that the player doesn't move diagonally
        if (Mathf.Abs(horizontalMovement) > 0.5f)
        {
            movement.x = horizontalMovement;
            movement.y = 0;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
           
        }
        else if (Mathf.Abs(verticalMovement) > 0.5f)
        {
            movement.x = 0;
            movement.y = verticalMovement;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }

        //Rotates the player face based on the movement so that the bullets come from where the player is facing
        if (horizontalMovement == -1)
        {
            //Left
            lookDir.z = 90.0f;
            if(transform.rotation.eulerAngles.z != 90.0f)
            {
                transform.localEulerAngles = lookDir;
            }
            playerDirection = direction.Left;
        }
        else if (horizontalMovement == 1)
        {
            //Right
            lookDir.z = 270.0f;

            if (transform.rotation.eulerAngles.z != 270.0f)
            {
                transform.localEulerAngles = lookDir;
            }

            playerDirection = direction.Right;
        }
        if (verticalMovement == -1)
        {
            //Down
            lookDir.z = 180.0f;
            if (transform.rotation.eulerAngles.z != 180.0f)
            {
                transform.localEulerAngles = lookDir;
            }
            playerDirection = direction.Down;
        }
        else if (verticalMovement == 1)
        {
            //Up
            lookDir.z = 0.0f;
            if (transform.rotation.eulerAngles.z != 0.0f)
            {
                transform.localEulerAngles = lookDir;
            }
            playerDirection = direction.Up;
        }


    }
}
