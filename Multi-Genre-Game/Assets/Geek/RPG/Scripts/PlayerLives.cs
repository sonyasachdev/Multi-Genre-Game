using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public Image[] hearts;
    private static int lives;
    public static int maxLives;
    public static GameObject player;
    public static float invulTimer;
    private bool invulnerable;
    
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        invulTimer = 2.0f;
        invulnerable = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Heart Array
        for(int i = 0; i<hearts.Length; i++)
        {
            if(i<maxLives)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        //Invulnerability timer
        if(invulnerable && invulTimer >0)
        {
            invulTimer -= Time.deltaTime;
        }
        else if(invulnerable && invulTimer<=0)
        {
            invulnerable = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Hurt Collision
        if(collision.gameObject.tag == "Enemy" && invulnerable == false)
        {
            lives--;
            //Set knockback

            //Check what direction player is facing and knock back
            //Also add timer
            //Resets timer
            invulnerable = true;
            invulTimer = 2.0f;
            Debug.Log(lives);

            /*
            //Kickback
            if (Movement.movement.x < 0)
            {
                //left
                Movement.movement.x -= 3;
                //rb.MovePosition(rb.position.x - 3.0f);
            }
            else
            {
                //right
                Movement.movement.x += 3;
            }
            if(Movement.movement.y < 0)
            {
                //down
                Movement.movement.y -= 3;
            }
            else
            {
                //up
                Movement.movement.y += 3;
            }*/
        }
    }
}
