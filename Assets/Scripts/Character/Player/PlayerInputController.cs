using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInputActions actions = null;
    private Rigidbody2D rigid2D = null;
    private Animator anim = null;
    private SpriteRenderer[] spriteRenderers = null;

    private Vector2 inputVec = Vector3.zero;

    public float speed = 3.0f;

    #region Unity 함수

    private void Awake()
    {
        actions = new();
        rigid2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Start()
    { 
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        if (inputVec.sqrMagnitude > 0.0f)
        {
            Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
            rigid2D.MovePosition(rigid2D.position + nextVec);
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }
        
    }

    private void OnEnable()
    {
        actions.Player.Enable();
        actions.Player.Move.performed += OnPlayerMove;
        actions.Player.Move.canceled += OnPlayerMove;
    }

    private void OnDisable()
    {
        actions.Player.Move.canceled -= OnPlayerMove;
        actions.Player.Move.performed -= OnPlayerMove;
        actions.Player.Disable();
    }

    #endregion

    #region Actions 함수
    private void OnPlayerMove(InputAction.CallbackContext context)
    {
        inputVec = context.ReadValue<Vector2>();

        if(inputVec.x < 0.0f)
        {
            foreach(var sr in spriteRenderers)
            {
                sr.flipX = true;
            }
        }
        else if(inputVec.x > 0.0f)
        {
            foreach (var sr in spriteRenderers)
            {
                sr.flipX = false;
            }
        }
    }
    #endregion
}
