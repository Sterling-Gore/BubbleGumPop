using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble_pop : MonoBehaviour
{

    [SerializeField] private Rigidbody2D Player_rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Player_rb.velocity.y < 0f)
        {
            Debug.Log("BubblePop");
            gameObject.SetActive(false);
        }
    }
}
