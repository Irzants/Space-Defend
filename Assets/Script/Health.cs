using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 30;

    //player take dmg form enemy when collide
    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer dmg = other.GetComponent<DamageDealer>(); //call script DamageDealer

        if(dmg != null)
        {
            TakeDamage(dmg.GetDamage());
            dmg.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
