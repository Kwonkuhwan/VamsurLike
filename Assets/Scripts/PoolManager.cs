using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리펩들을 보관할 변수
    public GameObject[] enemiesPrefabs;
    // 풀 담당을 하는 리스트
    private List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[enemiesPrefabs.Length];

        for (int index = 0; index < enemiesPrefabs.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject GetGameObject(int index)
    {
        GameObject select = null;

        // 선택한 풀의 놀고 (비활성화 된) 있는 게임오브젝트 접근
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                // 발견하면 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // 찾지 못하였으면
        if (!select)
        {
            // 새롭게 생성하여 select에 할당
            select = Instantiate(enemiesPrefabs[index], transform);
            pools[index].Add(select);

        }

        return select;
    }
}
