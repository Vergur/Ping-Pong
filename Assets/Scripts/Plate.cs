using UnityEngine;

public class Plate : MonoBehaviour
{
    protected float _defaultSpeed = 70;
    protected Rigidbody _rb;
    private Vector2 _direction;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void ChangePlateDirection(Vector2 direction)
    {
        this._direction = direction;
    }
    
    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0) 
        { 
            _rb.AddForce(_direction * _defaultSpeed);
        }
    }
}
