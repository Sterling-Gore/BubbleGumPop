using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_Bubble : MonoBehaviour
{
    public bool isShooting;
    [SerializeField] private Transform BubbleTemplate;
    [SerializeField] private Transform BubbleContainer;
    [SerializeField] private Camera cam;
    [SerializeField] private float Bubble_Spawn_Distance = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Mouse0) && !isShooting)
        {
            isShooting = true;
            StartCoroutine(ShootWait());
            Transform NewBubble = Instantiate(BubbleTemplate, BubbleContainer);
            NewBubble.gameObject.SetActive(true);
            Vector3 mousePos = Input.mousePosition;
            Vector3 point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

            Vector2 destinationPoint = new Vector2(point.x, point.y);
            Vector2 playerPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            Vector2 start_to_destination_vector = new Vector2(point.x - playerPosition.x, point.y - playerPosition.y) ;
            Vector2 bubbleSpawnPosition = new Vector2(playerPosition.x + start_to_destination_vector.normalized.x * Bubble_Spawn_Distance, playerPosition.y + start_to_destination_vector.normalized.y * Bubble_Spawn_Distance);


            //NewBubble.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            NewBubble.position = bubbleSpawnPosition;

            bubble_movement bubble_script = NewBubble.GetComponent<bubble_movement>();
            if(VectorIsBetweenPlayerAndBubbleSpawn(playerPosition, bubbleSpawnPosition, destinationPoint))
            {
                //if your cursor is inside the radius between where the bubble spawn and where the player is, the bubble will then not move from its spawn and its destination will be its spawn point
                bubble_script.destination = bubbleSpawnPosition;
            }
            else
            {
                bubble_script.destination = new Vector2(point.x, point.y);
            }
            bubble_script.start = true;


            //+transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime);
    
        }
    }

    bool VectorIsBetweenPlayerAndBubbleSpawn(Vector2 PlayerPos, Vector2 BubbleSpawnPos, Vector2 DestinationPos)
    {
        return (Vector2.Dot( (BubbleSpawnPos - PlayerPos).normalized, (DestinationPos- BubbleSpawnPos).normalized) <0f && Vector2.Dot( (PlayerPos-BubbleSpawnPos).normalized,  (DestinationPos-PlayerPos).normalized) <0f);
    }

    IEnumerator ShootWait()
    {
        float time = .4f;
        while(time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        isShooting = false;
    }

}
