using UnityEngine;

public class PlateController : Plate
{
    private Vector2 _direction;

    public void ChangePlateDirection(Vector2 direction)
    {
        this._direction = direction;
    }
    
    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0) 
        { 
            _rb.AddForce(_direction * 10);
        }
    }
}
