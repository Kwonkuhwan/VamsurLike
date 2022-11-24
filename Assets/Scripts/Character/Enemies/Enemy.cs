using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth, ITakeDamage, IAttack
{
    #region Unity 변수
    protected GameObject playerGameObj = null;
    protected Rigidbody2D rigid2D = null;
    protected CapsuleCollider2D capsuleCollider = null;
    #endregion

    #region 변수
    private float playerRange = 0.0f;
    public float speed = 2.0f;

    private float hp = 100.0f;
    private float maxHP = 100.0f;

    private float defencePower = 1.0f;
    private float attackPower = 1.0f;
    #endregion

    #region 프로퍼티
    public float HP
    {
        get => hp;
        set
        {
            if (hp != value)
            {
                hp = Mathf.Clamp(value, 0, maxHP);
                onHealthChage?.Invoke();
            }
        }
    }

    public float MaxHP => maxHP;

    public float DefencePower => defencePower;
    public float AttackPower => attackPower;
    #endregion

    #region 델리게이트
    public Action onHealthChage { get; set; }
    #endregion

    #region Unity 함수
    virtual protected void Awake()
    {
        playerGameObj = GameObject.Find("Player");
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    virtual protected void FixedUpdate()
    {
        Vector2 nextVec = GetNextVec().normalized * speed * Time.fixedDeltaTime;
        rigid2D.MovePosition(rigid2D.position + nextVec);
    }

    virtual protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        Attack(collision.GetComponent<Player>() as ITakeDamage);
    }

    virtual protected void OnTriggerExit2D(Collider2D collision)
    {
        
    }
    #endregion

    #region 선언 함수
    private Vector2 GetNextVec()
    {
        Rigidbody2D playerRigid2D = playerGameObj.GetComponent<Rigidbody2D>();

        Vector2 rangeVec = rigid2D.position - playerRigid2D.position;
        Vector2 nextVec = Vector2.zero;

        if (rangeVec.x > playerRange)
        {
            nextVec.x = -1;
        }
        else if (rangeVec.x < -playerRange)
        {
            nextVec.x = 1;
        }

        if (rangeVec.y > playerRange)
        {
            nextVec.y = -1;
        }
        else if (rangeVec.y < -playerRange)
        {
            nextVec.y = 1;
        }

        return nextVec;
    }

    public void Attack(ITakeDamage target)
    {
        if (target == null) return;

        float damage = AttackPower;
        target.TakeDamage(damage);
    }

    virtual public void TakeDamage(float damage)
    {
        float finalDamage = damage - defencePower;
        if (finalDamage < 1.0f)
        {
            finalDamage = 1.0f;
        }

        HP -= finalDamage;
    }
    #endregion
}
