using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private float curSpeed;
    private int direction = 1;

    [SerializeField] private Animator animator;
    private new Rigidbody2D rigidbody;

    private bool canControl = true;

    public UnityEvent completedWorkEvent;
    public UnityEvent completedSleepEvent;
    public UnityEvent completedDieEvent;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    async void Start()
    {
        curSpeed = -0.1f;
        canControl = false;
        await Task.Delay(2000);
        canControl = true;
        curSpeed = 0;
    }

    void Update()
    {
        if (dead)
            return;

        GetInput();
        UpdateDirection();
        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    void GetInput()
    {
        if (canControl == false)
            return;

        curSpeed = Input.GetAxis("Horizontal");
    }

    void ApplyMovement()
    {
        rigidbody.velocity = new Vector2(curSpeed * speed, rigidbody.velocity.y);
    }

    void UpdateDirection()
    {
        if (curSpeed < 0)
        {
            direction = -1;
        }
        else if (curSpeed > 0)
        {
            direction = 1;
        }

        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(direction, 1), 50 * Time.deltaTime);
    }

    void UpdateAnimator()
    {
        animator.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x));
    }

    public async Task MoveTo(float xPos)
    {
        canControl = false;
        while(Mathf.Abs(transform.position.x - xPos) > 0.1f)
        {
            await Task.Delay(1);
            if (transform.position.x - xPos < 0)
                curSpeed = 1;
            else
                curSpeed = -1;
        }
        canControl = true;
    }

    public async Task ToggleInteraction(string interactionName, float duration)
    {
        canControl = false;
        animator.SetTrigger(interactionName);
        rigidbody.velocity = Vector3.zero;
        curSpeed = 0;
        float gravity = rigidbody.gravityScale;
        rigidbody.gravityScale = 0;
        await Task.Delay((int)(1000 * duration));

        if (dead)
            return;

        canControl = true;
        rigidbody.gravityScale = gravity;
    }

    public void DrinkCoffee()
    {
        ToggleInteraction("Coffee", 3.5f);
    }

    public async void Work(Transform chair)
    {
        if (chair.localScale.x == -1)
            direction = 1;
        else
            direction = -1;

        transform.position = chair.transform.position;

        await ToggleInteraction("Work", 12.0f);

        animator.SetTrigger("Work");

        completedWorkEvent.Invoke();
    }

    public async void Sleep(Transform bed)
    {
        if (bed.localScale.x == -1)
            direction = 1;
        else
            direction = -1;

        transform.position = bed.transform.position;

        await ToggleInteraction("Sleep", 12.0f);

        animator.SetTrigger("Sleep");

        completedSleepEvent.Invoke();
    }


    private bool dead;
    public async void Die()
    {
        dead = true;
        await ToggleInteraction("Die", 10.0f);

        completedDieEvent.Invoke();
    }
}
