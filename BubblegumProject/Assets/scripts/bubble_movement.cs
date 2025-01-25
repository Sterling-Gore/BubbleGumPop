using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble_movement : MonoBehaviour
{
    public bool reachedDestination = false;
    public bool start = false;
    public Vector2 destination;

    // Update is called once per frame
    void Update()
    {
        if(!reachedDestination && start)
        {
            //transform.position = Vector2.Lerp(transform.position, destination, 2*Time.deltaTime);
            transform.position =  Vector2.MoveTowards(transform.position, destination, 6*Time.deltaTime);
            if(transform.position.x == destination.x && transform.position.y == destination.y)
            {
                reachedDestination = true;
                StartCoroutine(wait_to_pop());
                //Destroy(gameObject);
            }
        }
    }

    IEnumerator wait_to_pop()
    {
        float time = .75f;
        while(time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
