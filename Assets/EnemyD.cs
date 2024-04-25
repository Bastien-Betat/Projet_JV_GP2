using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyD : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;

    private void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(float damageAmount)
    {
        Debug.Log(health);
        health -= damageAmount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
