using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] Sprite EmptyBubbleSprite;
    [SerializeField] Sprite FilledBubbleSprite;
    [SerializeField] Sprite EmptyDashSprite;
    [SerializeField] Sprite FilledDashSprite;
    [SerializeField] Image dash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void usedDash()
    {
        dash.sprite = EmptyDashSprite;
        dash.color = new Color (1f, 1f,1f,.5f);
    }
    public void refreshDash()
    {
        dash.sprite = FilledDashSprite;
        dash.color = new Color (1f, 1f,1f,1f);
    }
}
