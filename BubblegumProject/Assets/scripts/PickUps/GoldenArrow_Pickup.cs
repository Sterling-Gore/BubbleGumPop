using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenArrow_Pickup : MonoBehaviour
{
    [SerializeField] Player_Movement movementScript;
    [SerializeField] UI_Controller UIController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D()
    {
        movementScript.unlockedDash = true;
        UIController.unlockDash();
        Destroy(gameObject);
    }
}
