using UnityEngine;

public class RacketPlayer2 : MonoBehaviour
{
    public float movementSpeed;

    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical2");      // v = vertical of Player2

        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, v) * movementSpeed;
    }
}
