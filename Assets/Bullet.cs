using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.TryGetComponent<EnemyD>(out EnemyD enemyDComponent))
        {
            enemyDComponent.TakeDamage(1);
        }

        Destroy(gameObject);
    }
}
