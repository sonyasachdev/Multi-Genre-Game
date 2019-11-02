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
            Destroy(player);
            Debug.Log("Player is Hurt");
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
