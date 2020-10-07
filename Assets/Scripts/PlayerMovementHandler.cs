using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float dodgeDistance;

    
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float up_down_input = Input.GetAxis("Vertical");
        float left_right_input = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(left_right_input, up_down_input) * speed * Time.fixedDeltaTime;
        //rb.AddForce(new Vector2(left_right_input, up_down_input) * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(left_right_input, up_down_input).normalized * dodgeDistance, ForceMode2D.Impulse);
        }
    }
}
