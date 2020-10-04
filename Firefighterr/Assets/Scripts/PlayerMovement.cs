using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float horizontralMove = 0f;
    public float runSpeed = 40f;
    public float walkSpeed = 20f;
    bool jump = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && jump != true)
        {
            horizontralMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontralMove));
        }
        else
        {
            horizontralMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontralMove));
        }

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W))
        {
            jump = true;

            animator.SetBool("isJump", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJump", false);
        jump = false;
    }

    private void FixedUpdate()
    {
        controller.Move(horizontralMove * Time.fixedDeltaTime, false, jump);
        Debug.Log(horizontralMove);
    }
}
