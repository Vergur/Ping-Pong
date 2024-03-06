using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rb;
    public float DefaultSpeed = 5f;
    private float _currentSpeed = 5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        AddStartImpulse();
    }
    
    private void FixedUpdate()
    {
        Vector2 direction = _rb.velocity.normalized;
        _rb.velocity = direction * _currentSpeed;
    }

    private void AddStartImpulse()
    {
        float x = -1;
        float y = 0.1f;
        
        Vector2 direction = new Vector2(x, y).normalized;
        _currentSpeed = DefaultSpeed;
        _rb.AddForce(direction * _currentSpeed, ForceMode.Impulse);
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.GetComponent("Plate")) return;
        
        Vector3 normal = collision.contacts[0].normal;
        Vector3 reflectedVelocity = Vector3.Reflect(_rb.velocity, normal);
        _rb.velocity = reflectedVelocity;
        _currentSpeed += 0.5f;
    }
}
