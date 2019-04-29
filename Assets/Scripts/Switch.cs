using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{

    public TextCanvasHandler textHandler;

    private bool entered;

    public UnityEvent toggleOn;
    public UnityEvent toggleOff;
    public bool toggled;

    public float toggleTime;

    private float toggleTimer;

    void Start()
    {
    }

    void Update()
    {
        if(Time.time < toggleTimer)
        {
            textHandler.TurnOff();
            return;
        }
        if (entered && Time.time >= toggleTimer)
        {
            textHandler.TurnOn();

            if(Input.GetButtonDown("Interact"))
            {
                Toggle();
            }
        }
    }

    void Toggle()
    {
        toggleTimer = Time.time + toggleTime;

        toggled = !toggled;

        InvokeToggle();
    }

    void InvokeToggle()
    {
        if (toggled)
            toggleOn.Invoke();
        else
            toggleOff.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            return;
        }

        entered = true;
        textHandler.SetText("press e to toggle switch");
        textHandler.TurnOn();
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
