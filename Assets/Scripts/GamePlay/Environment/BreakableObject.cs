using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] int points;
    [SerializeField] IntEvent ballhitEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            int force = 1;
            // Get force from the collision
            OnImpact(force);
        }    
    }

    private void OnImpact(float impact)
    {
        health -= impact;
        Debug.Log("hit");
        ballhitEvent.RaiseEvent(points);
    }
}
