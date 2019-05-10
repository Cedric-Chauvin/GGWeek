using Destructible2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombe : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject victory;

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

    public Transform explode;
    private Animator anim ;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = Camera.main.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Vector2.SignedAngle(Vector2.left, rb.velocity.normalized);
        transform.rotation= Quaternion.Euler( new Vector3(0, 0, angle));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Layers == (Layers | (1 << collision.gameObject.layer)))
        {
            D2dDestructible.StampAll(transform.position, Size*transform.localScale, Angle, StampTex, Hardness, Layers);
            Destroy(gameObject);
        }
        if (transform.gameObject.tag == "tank1")
        {
            if (collision.gameObject.tag == "tank2" )
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Instantiate(victory);
            }
        }else if(transform.gameObject.tag == "tank2")
        {
            if (collision.gameObject.tag == "tank1" )
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Instantiate(victory);
            }
        }

    }

    private void OnDestroy()
    {
        anim.SetTrigger("Shake");
        SoundControler._soundControler.PlaySound(SoundControler._soundControler._bomb);
        Transform instance = Instantiate(explode, transform.position, transform.rotation);
        instance.localScale = transform.localScale * Size;
        Destroy(instance.gameObject, 1);
    }
}
