using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    InputActions inputActions;

    public Player playerNum;

    Vector2 moveInput;
    Vector3 moveVector;

    Rigidbody rb;

    public float rotationSpeed;

    public float normalDrag;
    public float normalForce;

    public float hardDrag;
    public float hardForce;

    public bool hardAdvantage;
    public bool softAdvantage;
    public bool velcroAdvantage;

    public float velcroForce;

    public Rigidbody otherPlayer;

    private void Awake()
    {
        inputActions = new InputActions();

        if(playerNum == Player.Player1)
        {
            inputActions.Player1.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
            inputActions.Player1.Move.canceled += ctx => moveInput = Vector2.zero;
        }
        if (playerNum == Player.Player2)
        {
            inputActions.Player2.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
            inputActions.Player2.Move.canceled += ctx => moveInput = Vector2.zero;
        }

        rb = GetComponent<Rigidbody>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = new Vector3(moveInput.x, 0f, moveInput.y);
        if (hardAdvantage)
        {
            rb.drag = hardDrag;
            rb.AddForce(moveVector * hardForce * Time.deltaTime);
        }

        else
        {
            rb.drag = normalDrag;
            rb.AddForce(moveVector * normalForce * Time.deltaTime);
            
            
        }

        transform.forward = Vector3.Slerp(transform.forward, moveVector, Time.deltaTime * rotationSpeed);

        if (velcroAdvantage)
        {
            Vector3 friendDirection = (otherPlayer.transform.position - transform.position).normalized;
            rb.AddForce(friendDirection * Vector3.Distance(transform.position, otherPlayer.transform.position) * Time.deltaTime * velcroForce);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<HardAdvantage>(out HardAdvantage hardAdvantage))
        {
            StartCoroutine(HardAdvantageTimer(hardAdvantage.advantageTimer));
            Destroy(hardAdvantage.gameObject);
        }
        if (other.gameObject.TryGetComponent<SoftAdvantage>(out SoftAdvantage softAdvantage))
        {
            StartCoroutine(SoftAdvantageTimer(softAdvantage.advantageTimer));
            Destroy(softAdvantage.gameObject);
        }
        if (other.gameObject.TryGetComponent<VelcroAdvantage>(out VelcroAdvantage velcroAdvantage))
        {
            StartCoroutine(VelcroAdvantageTimer(velcroAdvantage.advantageTimer));
            Destroy(velcroAdvantage.gameObject);
        }
    }

    IEnumerator HardAdvantageTimer(float timer)
    {
        hardAdvantage = true;
        yield return new WaitForSeconds(timer);
        hardAdvantage = false;
    }

    IEnumerator SoftAdvantageTimer(float timer)
    {
        gameObject.layer = 6;

        yield return new WaitForSeconds(timer);
        gameObject.layer = 0;
    }

    IEnumerator VelcroAdvantageTimer(float timer)
    {
        velcroAdvantage = true;
        otherPlayer.gameObject.GetComponent<PlayerController>().velcroAdvantage = true;
        yield return new WaitForSeconds(timer);
        velcroAdvantage = false;
        otherPlayer.gameObject.GetComponent<PlayerController>().velcroAdvantage = false;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}

public enum Player
{
    Player1,
    Player2
}
