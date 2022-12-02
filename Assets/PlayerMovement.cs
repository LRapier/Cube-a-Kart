using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 20f;
    public float turnForce = 75f;
    public Vector3 point;

    void FixedUpdate()
    {
        Vector3 dir = (transform.forward) * forwardForce;
        dir.y = rb.velocity.y;

        rb.velocity = dir;

        point = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(point, -Vector3.up, turnForce * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        { 
            transform.RotateAround(point, Vector3.up, turnForce * Time.deltaTime);
        }
        if (Input.GetKey("left"))
        {
            transform.RotateAround(point, -Vector3.up, turnForce * Time.deltaTime);
        }
        else if (Input.GetKey("right"))
        {
            transform.RotateAround(point, Vector3.up, turnForce * Time.deltaTime);
        }
        if (rb.position.y < -1f)
        {
            Respawn();
        }
    }

    void Respawn()
    {

    }
}
