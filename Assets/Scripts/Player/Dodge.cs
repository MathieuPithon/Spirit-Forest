using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public int dashCost = 50;

    private Rigidbody2D rb;
    public PlayerStamina stamina;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }
    void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    direction = 1;
                    Debug.Log("gauche");
                }

            }

            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.D))
                {
                    direction = 2;
                    Debug.Log("droite");
                }

            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1 && stamina.CurrentStamina > dashCost)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                    stamina.LoseStamina(dashCost);
                    stamina.CallStaminaRegen();
                }
                else if (direction == 2 && stamina.CurrentStamina > dashCost)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                    stamina.LoseStamina(dashCost);
                    stamina.CallStaminaRegen();
                }
            }
        }
    }
}
