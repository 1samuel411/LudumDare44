using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCanvasHandler : MonoBehaviour
{

    public GameObject textCanvasPrefab;
    public float yPos = -3.84f;
    public bool on;

    private Animator textCanvasAnimator;
    private Text textCanvasText;
    private float disableTime;

    private void Awake()
    {
        GameObject newObj = Instantiate(textCanvasPrefab, new Vector3(transform.position.x, yPos, 0), Quaternion.identity);
        textCanvasAnimator = newObj.GetComponentInChildren<Animator>();
        textCanvasText = newObj.GetComponentInChildren<Text>();
    }

    void Update()
    {
        textCanvasAnimator.SetBool("On", on);

        if (Time.time >= disableTime && disableTime != 0)
        {
            disableTime = 0;
            on = false;
        }
    }

    public void SetText(string text)
    {
        textCanvasText.text = text;
    }

    public void TurnOff()
    {
        on = false;
        if(textCanvasAnimator != null)
            textCanvasAnimator.SetBool("On", on);
    }

    public void TurnOn()
    {
        if(textCanvasAnimator != null)
            textCanvasAnimator.SetBool("On", on);
        on = true;
    }

    public void SetTimer(float time)
    {
        disableTime = Time.time + time;
    }

    public void ShowText(string text, float time)
    {
        SetTimer(time);
        TurnOn();
        SetText(text);
    }
}
