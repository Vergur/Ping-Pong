using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rb;
    public float DefaultSpeed = 7f;
    private float _currentSpeed = 0f;
    private float _maxSpeed = 18f;

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

    public void IncreaseBallSpeed(float newSpeed)
    {
        _currentSpeed = _currentSpeed < _maxSpeed ? _currentSpeed + newSpeed : _maxSpeed;
    }
    
    public void ResetBallSpeed()
    {
        _currentSpeed = DefaultSpeed;
    }

    public void AddStartImpulse()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f) : Random.Range(0.5f, 1f);
        
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
    }
}
