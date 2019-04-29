using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject gameHolder;
    public Button button;

    private bool playing;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Play()
    {
        if (playing)
            return;

        playing = true;

        animator.SetTrigger("Play");
        button.interactable = false;
        gameHolder.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GameOver()
    {
        animator.SetTrigger("GameOver");
    }
}
