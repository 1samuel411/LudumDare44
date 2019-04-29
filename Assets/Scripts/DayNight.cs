using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{

    public Animator[] windows;
    public bool day;

    void Update()
    {
        for(int i = 0; i < windows.Length; i++)
        {
            windows[i].SetBool("Day", day);
        }
    }

    public void SetDaytime(bool day)
    {
        this.day = day;
    }
}
