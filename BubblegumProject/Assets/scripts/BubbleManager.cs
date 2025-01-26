using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    public int total_bubbles;
    public int available_bubbles;
    public int queued_bubbles;
    [SerializeField] private Player_Movement movementScript;

    void Start()
    {
        queued_bubbles = 0;
        total_bubbles = 1;
        available_bubbles = total_bubbles;
    }

    // Update is called once per frame
    void Update()
    {
        if(movementScript.IsGrounded())
        {
            refill_bubbles();
        }
    }
    
    public void Increase_Number_Of_Bubbles()
    {
        total_bubbles += 1;
        available_bubbles = total_bubbles;
    }

    public void refill_bubbles()
    {
        available_bubbles = Mathf.Clamp(available_bubbles+queued_bubbles, 0, total_bubbles);
        queued_bubbles = 0;
        //available_bubbles = total_bubbles;
    }

    public void decrease_bubbles()
    {
        available_bubbles -= 1;
    }
}
