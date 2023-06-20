using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float size;
    [SerializeField] float mass;

    protected Rigidbody2D rb;
    protected Vector2 initialPosition;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = rb.position;
        SetBodyType(RigidbodyType2D.Kinematic);
    }
    private void SetBodyType(RigidbodyType2D type)
    {
        rb.bodyType = type;
    }

    public void Drag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.position = mousePosition;    
    }

    public void MouseUp()
    {
        SetBodyType(RigidbodyType2D.Dynamic);
        Release();
    }

    private void Release()
    {
        Vector2 direction = (initialPosition - rb.position);
        rb.velocity = direction * speed;
    }

}
