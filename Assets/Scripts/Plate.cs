using UnityEngine;

public class Plate : MonoBehaviour
{
    protected Rigidbody _rb;
    public float DefaultSpeed = 5f;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.GetComponent("Ball")) return;
        
        Rigidbody ball = collision.rigidbody;
        Vector3 normal = collision.contacts[0].normal;
        Vector3 reflectedVelocity = Vector3.Reflect(collision.relativeVelocity, normal);
        ball.velocity = reflectedVelocity * DefaultSpeed;
        
    }
}
