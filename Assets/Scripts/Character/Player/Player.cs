using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHealth, ITakeDamage
{
    protected CapsuleCollider2D capsuleCollider;

    #region 변수
    private float hp = 100.0f;
    private float maxHP = 100.0f;

    private float defencePower = 1.0f;
    #endregion

    #region 프로퍼티
    public float HP
    {
        get => hp;
        set
        {
            if(hp != value)
            {
                hp = Mathf.Clamp(value, 0, maxHP);
                onHealthChage?.Invoke();
            }
        }
    }

    public float MaxHP => maxHP;

    public float DefencePower => defencePower;
    #endregion

    #region 델리게이트
    public Action onHealthChage { get; set; }
    #endregion


    #region Unity 함수
    virtual protected void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    virtual protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
        }
    }

    virtual protected void OnCollisionExit2D(Collision2D collision)
    {
        
    }
    #endregion


    #region 선언 함수
    public void TakeDamage(float damage)
    {
        float finalDamage = damage - defencePower;
        if(finalDamage < 1.0f)
        {
            finalDamage = 1.0f;
        }

        HP -= finalDamage;

        if (HP > 0.0f)
        {
            Debug.Log($"{HP}/{MaxHP} 플레이어 아직 살아있음");
        }
        else
        {
            Debug.Log("플레이어 죽어야함");
        }
    }
    #endregion

}
