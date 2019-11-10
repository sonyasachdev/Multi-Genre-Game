using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // todo: add behaviors that aren't "move right"
    // Start is called before the first frame update
    public float speed = 0.5f;
    public float health = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        CheckHealth();
    }

    void CheckHealth()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}
