﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    private PlayerInput input;

    [SerializeField]
    float rotateSpeed = 2.0f;
    private Vector2 m_Rotation;

    private void Awake()
    {
        input = new PlayerInput(); // create an new instance of input system
        input.Movements.Attack.performed += _ => Attack();
        input.Movements.Quit.performed += _ => QuitGame();

    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        // do not show cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        var look = input.Movements.Rotate.ReadValue<Vector2>();
        Rotate(look);
    }

    private void Rotate(Vector2 rotate)
    {
        if (rotate.sqrMagnitude < 0.01)
            return;
        var scaledRotateSpeed = rotateSpeed * Time.deltaTime;
        m_Rotation.y += rotate.x * scaledRotateSpeed;
        transform.localEulerAngles = m_Rotation;
    }

    private void Attack()
    {
        anim.SetTrigger("onAttack");
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void QuitGame()
    {
        UnityEngine.Debug.Log("Bye");
        Application.Quit();
    }
}