using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{

    public new SpriteRenderer renderer;
    public Sprite[] sheet;
    public float speed;
    public float stoppingSpeed, startingSpeed;

    private float timer;
    private int index;

    private bool toggled = true;

    private bool stopping, starting;
    private int stoppingIndexes, startingIndexes;

    public void Stop(int indexes)
    {
        if (starting)
            return;

        stopping = true;
        stoppingIndexes = indexes;
    }

    public void TurnOn(int indexes)
    {
        if (stopping)
            return;

        toggled = true;
        starting = true;
        startingIndexes = indexes;
    }

    void Update()
    {
        if(Time.time >= timer)
        {
            timer = Time.time + speed;

            if (toggled)
            {
                index++;
                if (index >= sheet.Length)
                    index = 0;

                renderer.sprite = sheet[index];

                if (stopping)
                {
                    stoppingIndexes--;
                    speed += stoppingSpeed;
                    if (stoppingIndexes < 0)
                    {
                        toggled = false;
                        stopping = false;
                    }
                }

                if(starting)
                {
                    startingIndexes--;
                    speed += startingSpeed;
                    if (startingIndexes < 0)
                        starting = false;
                }
            }
        }
    }
}
