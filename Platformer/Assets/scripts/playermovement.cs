
using UnityEngine;

public class playermovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();

    }


    private void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //flipping left-right

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1); 


        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);
    }



}
