using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlate : Plate
{
    [SerializeField] private Rigidbody ball;

    private void FixedUpdate()
    {
        Vector2 forceDirection = ball.position.y > _rb.position.y ? Vector2.up : Vector2.down;
        _rb.AddForce(forceDirection * _defaultSpeed);
    }
}
