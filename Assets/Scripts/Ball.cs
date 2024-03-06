using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rb;
    public float DefaultSpeed = 5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        AddStartImpulse();
    }
    
    private void FixedUpdate()
    {
        Vector2 direction = _rb.velocity.normalized;
        _rb.velocity = direction * DefaultSpeed;
    }

    private void AddStartImpulse()
    {
        float x = -1;
        float y = 0.1f;
        
        Vector2 direction = new Vector2(x, y).normalized;
        _rb.AddForce(direction * DefaultSpeed, ForceMode.Impulse);
    }
}
