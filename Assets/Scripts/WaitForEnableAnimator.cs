using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WaitForEnableAnimator : MonoBehaviour
{

    public Animator animator;

    async void Start()
    {
        await Task.Delay(1000);
        animator.enabled = true;
    }

    void Update()
    {

    }
}
