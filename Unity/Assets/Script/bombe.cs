using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombe : MonoBehaviour
{

    Rigidbody2D rb;
    int dir = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity += new Vector2(10 * dir, 0);
    }

    // Start is called before the first frame update
    public void ChangeDirection()
    {
        dir *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
