using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyD") {
            Debug.Log("col");
            EnemyD enemyDComponent = collision.gameObject.GetComponent<EnemyD>();
            enemyDComponent.TakeDamage(1);
            Destroy(gameObject);
        }
 
    }
}
