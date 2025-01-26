using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenCircle_Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] BubbleManager bubblemanager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D()
    {
        bubblemanager.Increase_Number_Of_Bubbles();
        Destroy(gameObject);
    }
}
