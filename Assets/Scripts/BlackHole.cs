using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] Transform center;
    [SerializeField] CircleCollider2D circleCollider;
    [SerializeField] float radius;
    [SerializeField] float appliedForce;

    // Start is called before the first frame update
    void Start()
    {
        circleCollider.radius = radius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    public void ApplyForce(Rigidbody2D rigidbody)
    {
        float distX = rigidbody.position.x - center.position.x;
        float distY = rigidbody.position.y - center.position.y;
        rigidbody.AddForce(new Vector2(appliedForce * (distX/radius) * -1 * Time.fixedDeltaTime, appliedForce * (distY/radius) * -1 * Time.fixedDeltaTime));
    }

    public void OnDrawGizmos()
    {
        Color color = new Color();
        color = Color.magenta;
        color.a = 0.5f;
        Gizmos.color = color;
        Gizmos.DrawSphere(center.position, radius);
    }
}
