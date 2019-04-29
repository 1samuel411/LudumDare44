using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Door : MonoBehaviour
{

    public string from;
    public string to;
    public bool alt;
    public int[] storyReqs;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (storyReqs.Contains(RoomSystem.instance.storyPos) == false)
            return;

        if (collision.tag != "Player")
            return;

        RoomSystem.instance.EnterRoom(from, to, alt);
    }
}
