using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{

    public TextCanvasHandler textHandler;
    public string instructionText;
    public float waitTime;
    public UnityEvent toggle;

    private bool entered;
    private float waitTimer;

    public bool requireInput = true;

    public int[] storyRequirements;

    void Start()
    {
    }

    void Update()
    {
        if (storyRequirements.Length > 0 && storyRequirements.Contains(RoomSystem.instance.storyPos) == false)
        {
            textHandler.TurnOff();
            return;
        }
        if (Time.time < waitTimer)
        {
            textHandler.TurnOff();
            return;
        }
        if(entered)
        {
            if (requireInput)
            {
                textHandler.TurnOn();
                if (Input.GetButtonDown("Interact"))
                {
                    Toggle();
                }
            }
            else
            {
                Toggle();
            }
        }
    }

    void Toggle()
    {
        waitTimer = Time.time + waitTime;
        toggle.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            return;
        }

        entered = true;
        textHandler.SetText("press e to " + instructionText);
        if(requireInput)
            textHandler.TurnOn();
    }

    private void OnDisable()
    {
        entered = false;
        textHandler.TurnOff();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            return;
        }

        entered = false;
        textHandler.TurnOff();
    }

}
