using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Destructible2D;

public class BombeFrag : MonoBehaviour
{
    [Tooltip("The GameObject layers this can stamp")]
    public LayerMask Layers = -1;

    [Tooltip("The shape of the stamp")]
    public Texture2D StampTex;

    [Tooltip("The size of the stamp")]
    public Vector2 Size = Vector2.one;

    [Tooltip("The angle of the stamp")]
    public float Angle;

    [Tooltip("The hardness of the stamp")]
    public float Hardness = 1.0f;

    public Transform bombe;
    public Transform explode;
    public int nbFragmentation;

    Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Layers == (Layers | (1 << collision.gameObject.layer)))
        {
            D2dDestructible.StampAll(transform.position, Size, Angle, StampTex, Hardness, Layers);
            Transform instance = Instantiate(explode, transform.position, transform.rotation);
            Destroy(instance.gameObject, 1);

            for(int i =0; i < nbFragmentation; i++)
            {
                float dir =Random.Range(0, 180);
                if ( dir < 90)
                    dir = 360 - dir;
                else 
                    dir -= 90;

                Transform newBombe = Instantiate(bombe, transform.position, transform.rotation);
                newBombe.localScale /= 2;
                newBombe.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, dir) * rb.velocity;
                Destroy(newBombe.gameObject, 1);
            }

            Destroy(gameObject);
        }
    }
}
