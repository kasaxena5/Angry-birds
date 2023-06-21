using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] float speed;
    [SerializeField] float size;
    [SerializeField] float mass;
    
    [Header("Events")]
    [SerializeField] private Event ballReleasedEvent;
    [SerializeField] private Event ballExpiredEvent;
    [SerializeField] private IntEvent ballHitEvent;

    [Header("Prefabs")]
    [SerializeField] Transform launchPad;

    protected Rigidbody2D rb;
    protected Vector2 restPosition;
    public bool IsReady { get; private set; }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        restPosition = rb.position;
        SetBodyType(RigidbodyType2D.Kinematic);
        IsReady = false;
    }


    private void SetBodyType(RigidbodyType2D type)
    {
        rb.bodyType = type;
    }

    private void SetLaunchVelocity()
    {
        Vector2 initialPosition = launchPad.position;
        Vector2 direction = (initialPosition - rb.position);
        rb.velocity = direction * speed;
    }

    public void Drag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.position = mousePosition;
    }

    public void Release()
    {
        SetBodyType(RigidbodyType2D.Dynamic);
        SetLaunchVelocity();
    }

    public Vector2 GetRestPosition()
    {
        return restPosition;
    }

    public Vector2 GetLaunchPosition()
    {
        return launchPad.position;
    }

    public void MoveToNextRestPosition(Vector2 target)
    {
        //TODO: Add Animations
        transform.position = target;
        restPosition = target;
    }

    public void MoveToReadyState()
    {
        IsReady = true;
        ballReleasedEvent.RaiseEvent();
    }

}
