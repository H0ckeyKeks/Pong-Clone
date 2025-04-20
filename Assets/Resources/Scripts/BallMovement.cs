using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float movementSpeed;
    public float extraSpeedPerHit;
    public float maxExtraSpeed;

    int hitCounter = 0;

    void Start()
    {
        StartCoroutine(this.StartBall());
    }

    private void PositionBall(bool isStartingPlayer1)
    {
        this.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);

        if (isStartingPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(-100, 0, 0);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(100, 0, 0);
        }
    }

    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        this.PositionBall(isStartingPlayer1);
        this.hitCounter = 0;
        yield return new WaitForSeconds(2);
        if (isStartingPlayer1)
        {
            this.MoveBall(new Vector2(-1, 0));  // makes the ball move to the left
        }
        else
        {
            this.MoveBall(new Vector2(1, 0));   // makes the ball move to the right
        }
    }


    public void MoveBall(Vector2 dir) // dir = direction
    {
        dir = dir.normalized;

        float speed = this.movementSpeed + this.hitCounter * this.extraSpeedPerHit;

        // To apply speed to the ball force needs to be added to the rigidbody as the rigidbody is the physics aspect of the ball
        // Getting the rigidbody component of the game Object -> the ball
        Rigidbody2D rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();

        rigidBody2D.linearVelocity = dir * speed;
    }

    public void IncreaseHitCounter()
    {
        if(this.hitCounter * this.maxExtraSpeed <= this.maxExtraSpeed)
        {
            this.hitCounter++;
        }
    }
}
