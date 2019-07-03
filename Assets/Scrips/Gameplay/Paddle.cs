using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 velocity;
    Vector2 thrustDirection = new Vector2(1, 0);
    BoxCollider2D boxCollider;
    float halfColliderWidth;
    float halfColliderHeight;
    const float BounceAngleHalfRange = 60.0f  *Mathf.Deg2Rad;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        halfColliderWidth = 5 / 2;
        halfColliderHeight = 5 / 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float horizontalDelta = Input.GetAxis("Horizontal") * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.fixedDeltaTime;
        Vector2 newPosition = rb2D.position + new Vector2(horizontalDelta, 0f);
        newPosition.x = CalculateClampedX(newPosition.x);
        rb2D.MovePosition(newPosition);

    }


    float CalculateClampedX(float x) {
        if (x <= ScreenUtils.ScreenLeft){

        return (x = ScreenUtils.ScreenLeft);
        }
        if (x >= ScreenUtils.ScreenRight){

        return (x = ScreenUtils.ScreenRight);
        }
        else { 
         return (x);
            }
        }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") && CheckCollisionOnTop(coll) == true)
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    bool CheckCollisionOnTop(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {

            if ((transform.position.y - coll.transform.position.y) / halfColliderHeight <= 0.05f)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        else
        {
            return (false);
        }
    }
}
