using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float maxSearchDistance = 5.0f;

    private bool isLerping;
    private Vector2 lastDirection;
    private Vector2 followMovement;

    Rigidbody2D rb;
    GameObject player;

    Vector2 randomDirection;
    Vector2 startPosition;
    Vector2 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        // Set up a random direction for the enemy to move in
        randomDirection.x = Random.Range(-1, 2);
        randomDirection.y = Random.Range(-1, 2);

        // Make sure it has a default direction 
        if(randomDirection.x == 0 && randomDirection.y == 0)
        {
            randomDirection.x = 1;
        }

        // Calculate start and end position for lerping
        startPosition = transform.position;
        endPosition.x = transform.position.x + randomDirection.x;
        endPosition.y = transform.position.y + randomDirection.y;
        lastDirection = randomDirection;

        isLerping = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Fixed update method
    void FixedUpdate()
    {
        if (player != null && !FoundPlayer()) // Did not find the player
        {
            if (!isLerping)
            {
                // Calculate start and end position for lerping
                startPosition = transform.position;
                endPosition.x = transform.position.x + followMovement.x;
                endPosition.y = transform.position.y + followMovement.y;
                RotateTowardsPosition(endPosition);
            }

            Lerp();
            isLerping = true;
        }
        else // Found the player!
        {
            if (player != null)
            {
                FollowPlayer();
                isLerping = false;
            }
        }
    }

    /// <summary>
    /// Start the lerping pattern (back and forth between two positions, 'pacing')
    /// </summary>
    private void Lerp()
    {
        // Lerp enemy between two points
        float pingPong = Mathf.PingPong(Time.time * moveSpeed, 1);
        rb.MovePosition(Vector2.Lerp(startPosition, endPosition, pingPong));

        // If ping pong is near end if the lerp, rotate back towards start point
        // If it is near 0 (or the start), rotate back towards end point 
        if (pingPong + 0.05f > 1)
        {
            RotateTowardsPosition(startPosition);
        }
        else if (pingPong - 0.05f < 0)
        {
            RotateTowardsPosition(endPosition);
        }
    }

    /// <summary>
    /// Searches for the player and returns whether or not the player has been found (or is within the range). 
    /// </summary>
    /// <returns>Returns true if the player has been found (is within range), false otherwise</returns>
    bool FoundPlayer()
    {
        var distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < maxSearchDistance)
        {
            Debug.Log("True");
            return true;
        }

        Debug.Log("false");
        return false;
    }

    /// <summary>
    /// Follows the player based on their position
    /// </summary>
    public void FollowPlayer()
    {
        RotateTowardsPosition(player.transform.position);
        Vector3 direction = (player.transform.position - transform.position).normalized;
        followMovement = direction;
        var value = (Vector2)transform.position + ((Vector2)direction * moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(value);
    }

    public void RotateTowardsPosition(Vector2 position)
    {
        // Rotate
        Vector2 lookDirection = position - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
