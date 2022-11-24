using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemiesObj = null;
    GameObject enemyObj = null;

    private void Start()
    {
        int createRand = Random.Range(1, 11);

        for (int i = 0; i < createRand; i++)
        {
            int enemyRand = Random.Range(0, enemiesObj.Length);
            enemyObj = Instantiate(enemiesObj[enemyRand], new Vector3(transform.position.x + Random.Range(0.0f, 0.5f), transform.position.y + Random.Range(0.0f, 0.5f), 0), Quaternion.identity);
            enemyObj.transform.parent = transform;
        }
    }

    private void Update()
    {
        if(transform.childCount == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
