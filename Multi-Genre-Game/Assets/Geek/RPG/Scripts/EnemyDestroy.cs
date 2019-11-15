using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public GameObject player;
    public float health = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            TakeDamage(50);

            Debug.Log("Enemy health: " + health);
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
    /// Make the enemy take damage and destroy the game object when the enemy is dead
    /// </summary>
    /// <param name="damageAmount">The amount of damage</param>
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (!IsAlive()) Destroy(gameObject);
    }

    /// <summary>
    /// Checks if the enemy is still alive
    /// </summary>
    /// <returns>True if the enemy is alive, false if they are dead</returns>
    public bool IsAlive()
    {
        if (health > 0) return true;
        return false;
    }
}
