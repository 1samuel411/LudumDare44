using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CoffeMachine : MonoBehaviour
{

    public Transform coffeCup;
    public Sprite machineOnSprite, machineOffSprite;
    public GameObject beginCoffeeInteract, grabCoffeeInteract;

    private new SpriteRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public async void MakeCoffe()
    {
        beginCoffeeInteract.SetActive(false);
        renderer.sprite = machineOnSprite;
        coffeCup.gameObject.SetActive(true);
        await Task.Delay(3000);
        renderer.sprite = machineOffSprite;
        grabCoffeeInteract.SetActive(true);
    }

    public async void GrabCoffee()
    {
        grabCoffeeInteract.SetActive(false);
        coffeCup.gameObject.SetActive(false);
        await Task.Delay(3500);
        beginCoffeeInteract.SetActive(true);
    }
}
