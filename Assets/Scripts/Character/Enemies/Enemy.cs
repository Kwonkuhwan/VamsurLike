using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Unity 변수
    public Rigidbody2D target = null;                       // 플레이어
    protected Rigidbody2D rigid2D = null;
    protected SpriteRenderer spriter = null;
    protected CapsuleCollider2D capsuleCollider = null;
    #endregion

    #region 변수
    public float speed = 2.0f;

    private bool isLive = true;
    #endregion


    #region 델리게이트
    public Action onHealthChage { get; set; }
    #endregion

    #region Unity 함수
    virtual protected void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }

    virtual protected void FixedUpdate()
    {
        if (!isLive) return;

        Vector2 dirVec = target.position - rigid2D.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid2D.MovePosition(rigid2D.position + nextVec);
        rigid2D.velocity = Vector2.zero;
    }

    virtual protected void LateUpdate()
    {
        if (!isLive) return;

        spriter.flipX = target.position.x < rigid2D.position.x;
    }
    #endregion

    #region 선언 함수
    #endregion
}
