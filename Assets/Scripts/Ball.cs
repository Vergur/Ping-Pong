using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rb;
    public float DefaultSpeed = 7f;
    private float _currentSpeed = 0f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        Vector2 direction = _rb.velocity.normalized;
        _rb.velocity = direction * _currentSpeed;
    }
    
    public void ResetPosition()
    {
        _rb.position = _rb.velocity = Vector2.zero;
    }

    public void AddStartImpulse()
    {
        float x = -1;
        float y = 0.4f;
        
        Vector2 direction = new Vector2(x, y).normalized;
        _currentSpeed = DefaultSpeed;
        _rb.AddForce(direction * _currentSpeed, ForceMode.Impulse);
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent("ScoreSurfaces")) return;
        
        Vector3 normalVector = collision.contacts[0].normal;
        Vector3 reflectedVelocity = Vector3.Reflect(_rb.velocity, normalVector);
        _rb.velocity = reflectedVelocity;
        
        if (!collision.gameObject.GetComponent("Plate")) return;
        _currentSpeed += 0.5f;
    }
}
