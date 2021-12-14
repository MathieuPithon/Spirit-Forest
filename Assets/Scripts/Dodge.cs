using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    private bool isDashing;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public int dashCost = 50;
    
    private Rigidbody2D rb;
    public PlayerCombat combat;
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
            if (Input.GetKeyDown(KeyCode.LeftAlt) && !combat.faceRight)
                direction = 2;
            else if (Input.GetKeyDown(KeyCode.LeftAlt) && combat.faceRight)
                direction = 1;
        } else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                isDashing = false;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            } else
            {
                dashTime -= Time.deltaTime;
                if (!isDashing && stamina.CurrentStamina > dashCost)
                {
                    switch (direction)
                    {
                        case 1:
                            rb.velocity = Vector2.left * dashSpeed;
                            stamina.LoseStamina(dashCost);
                            stamina.CallStaminaRegen();
                            isDashing = true;
                            break;
                        case 2:
                            rb.velocity = Vector2.right * dashSpeed;
                            stamina.LoseStamina(dashCost);
                            stamina.CallStaminaRegen();
                            isDashing = true;
                            break;
                    }
                }                
            }
        }
    }
}
