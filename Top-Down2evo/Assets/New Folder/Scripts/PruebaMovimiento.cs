using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PruebaMovimiento : MonoBehaviour
{

   
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private Vector2 movement;
    private float movimientoX;
    private float movimientoY;
    private Animator animator;

    bool isAttacking = false;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //ataque
        if (Input.GetKeyDown(KeyCode.RightAlt))
            {
            animator.Play("Ataque");
            isAttacking = true;
        }

        Movimiento();



    }

    #region Input Methods
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    #endregion

    void Movimiento()
    {
        //animacion movimiento
        if (isAttacking) return;

        movimientoX = Input.GetAxisRaw("Horizontal");
        movimientoY = Input.GetAxisRaw("Vertical");

        animator.SetFloat("MovimientoX", movimientoX);
        animator.SetFloat("MovimientoY", movimientoY);

        if (movimientoX != 0 || movimientoY != 0)
        {
            animator.SetFloat("UltimoX", movimientoX);
            animator.SetFloat("UltimoY", movimientoY);
        }
    }

    void FinAtaque()
    {
        isAttacking = false;
    }

}
