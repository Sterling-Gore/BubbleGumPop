using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble_pop : MonoBehaviour
{
    public float popJumpSpeed = 18f;
    [SerializeField] private Rigidbody2D Player_rb;
   // [SerializeField] private Transform Player;
    [SerializeField] private LayerMask PlayerLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if you are in the bubble and falling, pop the bubble and launch the player up
        //if(Physics2D.OverlapCircle(Player.position, 0.2f, bubbleLayer) && Player_rb.velocity.y < 0f)
        if(Physics2D.OverlapCircle(gameObject.transform.position, 0.2f, PlayerLayer) && Player_rb.velocity.y < 0f)
        {
            Player_rb.velocity = new Vector2(Player_rb.velocity.x, popJumpSpeed);
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Player_rb.velocity.y < 0f)
        {
            Debug.Log("BubblePop");
           // gameObject.SetActive(false);
        }
    }
}
