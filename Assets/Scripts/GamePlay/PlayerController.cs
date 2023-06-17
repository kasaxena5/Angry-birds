using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public enum PlayerState
    {
        Relaxed,
        Dragging,
        Released
    }

    [Header("Configs")]
    [SerializeField] PlayerState state = PlayerState.Relaxed;
    [Range(1, 5)][SerializeField] float ejectSpeed;

    Rigidbody2D rb;
    Vector2 initialPosition;

    public void SetState(PlayerState newState)
    {
        state = newState;
    }

    public PlayerState GetState()
    {
        return state;
    }

    private void OnMouseDrag()
    {
        PlayerState state = GetState();
        if (state == PlayerState.Dragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.position = mousePosition;
        }
    }

    private void OnMouseUp()
    {
        PlayerState state = GetState();
        if (state == PlayerState.Dragging)
        {
            SetState(PlayerState.Released);
            rb.bodyType = RigidbodyType2D.Dynamic;
            Release();
        }
    }

    private void Release()
    {
        Vector2 direction = (initialPosition - rb.position);
        rb.velocity = direction * ejectSpeed;
    }

    private void OnMouseDown()
    {
        PlayerState state = GetState();
        if(state == PlayerState.Relaxed)
            SetState(PlayerState.Dragging);
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = rb.position;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
}
