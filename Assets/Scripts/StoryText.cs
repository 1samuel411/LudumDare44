using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryText : MonoBehaviour
{

    public int storyLinePositionReq;
    public string text;
    private TextCanvasHandler handler;

    void Awake()
    {
        handler = GetComponent<TextCanvasHandler>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;

        if (RoomSystem.instance.storyPos != storyLinePositionReq)
            return;

        RoomSystem.instance.storyPos++;
        handler.ShowText(text, 2.0f);
    }
}
