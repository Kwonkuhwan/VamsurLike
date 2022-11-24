using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemySpawner : MonoBehaviour
{
    public GameObject spawner = null;
    public float randomRange = 5.0f;
    public float maxSpawnerCount = 100;

    private Player player = null;

    private float currentTime = 0.0f;
    private float coolTime = 2.0f;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > coolTime)
        {
            SpawnerCreate();
            CurrentTimeClear();
        }
    }

    private void SpawnerCreate()
    {
        if (transform.childCount < maxSpawnerCount)
        {
            Rigidbody2D playerRigid2D = player.GetComponent<Rigidbody2D>();
            Vector3 randVec = new Vector3(Random.Range(-randomRange + playerRigid2D.position.x, randomRange + playerRigid2D.position.x), Random.Range(-randomRange + playerRigid2D.position.y, randomRange + playerRigid2D.position.y), 0);

            GameObject obj = Instantiate(spawner, randVec, Quaternion.identity);
            obj.transform.parent = transform;
        }
    }

    private void CurrentTimeClear()
    {
        currentTime = 0.0f;
    }
}
