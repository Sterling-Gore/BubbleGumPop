using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    [SerializeField] private Transform  groundCheck;
    [SerializeField] private LayerMask DeathLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.OverlapCircle(groundCheck.position, 0.2f, DeathLayer))
        {
            death();
        }
    }
    void death()
    {
        SceneManager.LoadSceneAsync("Game Over");
    }
}
