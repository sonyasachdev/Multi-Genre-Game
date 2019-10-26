using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{

    //For Animation when Bullet hits object
    //public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //For Animation Hit Effect
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

        //Destroys Bullet on Impact
        Destroy(gameObject);
    }

}