using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_Bubble : MonoBehaviour
{
    [SerializeField] private Transform BubbleTemplate;
    [SerializeField] private Transform BubbleContainer;
    [SerializeField] private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Mouse0) )
        {
            Transform NewBubble = Instantiate(BubbleTemplate, BubbleContainer);
            NewBubble.gameObject.SetActive(true);
            Vector3 mousePos = Input.mousePosition;
            Vector3 point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
            NewBubble.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

            bubble_movement bubble_script = NewBubble.GetComponent<bubble_movement>();
            bubble_script.destination = new Vector2(point.x, point.y);
            bubble_script.start = true;


            //transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime);
    
        }
    }

}
