using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    #region Unity 함수
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
    }
    #endregion

    #region 선언 함수
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        if (HP > 0.0f)
        {
            Debug.Log("박쥐 아직 살아있음");
        }
        else
        {
            Debug.Log("박쥐 죽어야함");
        }
    }
    #endregion
}
