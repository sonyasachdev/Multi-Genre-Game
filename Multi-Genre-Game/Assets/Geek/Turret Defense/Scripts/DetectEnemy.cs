using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    public bool enemyDetected;
    public List<GameObject> enemiesInRange = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        enemyDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            enemyDetected = true;
            enemiesInRange.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(collision.gameObject);
        }
        if (enemiesInRange.Count == 0)
            enemyDetected = false;
    }
}
