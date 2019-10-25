using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int speed;
    public int lifespan;
    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
        lifespan = 3;
        Destroy(this.gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
