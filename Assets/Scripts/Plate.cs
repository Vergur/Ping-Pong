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
    
    public void ResetPosition()
    {
        _rb.velocity = Vector2.zero;
        _rb.position = new Vector2(_rb.position.x, 0f);
    }
    
    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0) 
        { 
            _rb.AddForce(_direction * _defaultSpeed);
        }
    }
}
