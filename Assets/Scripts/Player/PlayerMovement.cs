using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    float x;
    float y;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vector = new Vector3(0, 0, 0);

        vector.Set(x * speed, y * speed, 0);

        rb.velocity = vector;

    }
}
