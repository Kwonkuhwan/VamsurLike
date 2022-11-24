using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInputActions actions = null;
    private Rigidbody2D rigid2D = null;
    private Vector2 inputVec = Vector3.zero;
    public float speed = 3.0f;

    #region Unity 함수

    private void Awake()
    {
        if(actions == null) actions = new();
        if(rigid2D == null) rigid2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid2D.MovePosition(rigid2D.position + nextVec);
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
    }
    #endregion
}
