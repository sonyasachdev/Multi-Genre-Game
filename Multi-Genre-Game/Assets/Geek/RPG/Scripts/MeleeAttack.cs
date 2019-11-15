using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    SpriteRenderer playerSpriteRenderer;
    Vector2 mousePos;
    public LayerMask enemyLayer;
    //Drag the Rigidbody in
    public Rigidbody2D rb;
    //Camera Variable
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(1))
        {
            Attack();
        }
    }

    /// <summary>
    /// Player attack
    /// </summary>
    public void Attack()
    {
        // Get the direction the player is looking
        var lookDirection = mousePos - rb.position;

        // Raycast for the hit collider
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lookDirection, 1.0f, enemyLayer);

        // Check to see if they hit an enemy
        if (hit.collider != null )
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<EnemyDestroy>().TakeDamage(50);
            }
        }
    }
}
