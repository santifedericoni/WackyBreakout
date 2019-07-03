using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Vector2 speed = new Vector2(ConfigurationUtils.BallImpulseForce * Time.deltaTime, -ConfigurationUtils.BallImpulseForce);
        rb2D.AddForce(speed,0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDirection(Vector2 direction)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float dirMagnitude;
        dirMagnitude = direction.magnitude * rb.velocity.magnitude;
        rb.velocity = direction*5;
    }

    public void SetDirectionBlock(Vector2 direction)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float dirMagnitude;
        dirMagnitude = direction.magnitude * rb.velocity.magnitude;
        rb.velocity = direction * -5;
    }
}
