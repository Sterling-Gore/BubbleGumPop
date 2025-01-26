using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Sprite fall;
    [SerializeField] private Sprite jump;
    [SerializeField] private Sprite idle;
    [SerializeField] private Sprite dash;
    [SerializeField] private Player_Movement movementScript;
    [SerializeField] private shoot_Bubble shootScript;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private Rigidbody2D Player_rb;

    [SerializeField] private RuntimeAnimatorController walkingAnimation;
    [SerializeField] private RuntimeAnimatorController ShootingAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movementScript.isDashing)
        {
            renderer.sprite = dash;
            animator.enabled = false;
            Debug.Log("Dashing");
        }
        else if(shootScript.isShooting)
        {
            animator.runtimeAnimatorController = ShootingAnimation;
            animator.enabled = true;
            Debug.Log("Shooting");
        }
        else if(!movementScript.IsGrounded())
        {
            if(Player_rb.velocity.y < 0f)
            {
                renderer.sprite = fall;
                animator.enabled = false;
                Debug.Log("Fall");
            }
            else
            {
                renderer.sprite = jump;
                animator.enabled = false;
                Debug.Log("Jump");
            }
        }
        else if(Mathf.Abs(Player_rb.velocity.x) > 0f)
        {
            animator.runtimeAnimatorController = walkingAnimation;
            animator.enabled = true;
            Debug.Log("walking");
        }
        else  
        {
            renderer.sprite = idle;
            animator.enabled = false;
            Debug.Log("idle");
            
        }
    }
}
