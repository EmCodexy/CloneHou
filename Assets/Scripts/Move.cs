using UnityEngine;

public class Move : MonoBehaviour
{
    
    public float plMaxSpeed;
    private Rigidbody2D plRigidBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal -= plMaxSpeed;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal += plMaxSpeed;
        }

        float vertical = 0f;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vertical -= plMaxSpeed;
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            vertical += plMaxSpeed;
        }

        Vector2 moving = new Vector2(horizontal, vertical);

        plRigidBody.linearVelocity = moving;

        if (plRigidBody.linearVelocity.magnitude > plMaxSpeed)
        {


            plRigidBody.linearVelocity = plRigidBody.linearVelocity.normalized * plMaxSpeed;
        }

    }
}
