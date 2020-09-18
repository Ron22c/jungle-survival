using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public ObjectPooler enemyPooler;
    
    public void spwnEnemies(Vector3 position, float platformWidth) {
        int random = Random.Range(0, 100);
        if (random < 50) {
            return;
        }

        GameObject enemy = enemyPooler.GetPooledGameObject();
        enemy.transform.position = new Vector3(
            position.x,
            position.y,
            0
        );
        enemy.SetActive(true);
    } 
}
