using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public GameObject player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            //Damage Player Method Called
            if(PlayerLives.maxLives <= 0)
            {
                //Destroy(player);
                //Call the Hurt Method
            }
            
            
        }
    }

    /// <summary>
    /// Make the enemy take damage
    /// </summary>
    public void TakeDamage()
    {
        Destroy(gameObject);
    }
}
