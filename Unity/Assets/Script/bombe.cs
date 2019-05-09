using Destructible2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombe : MonoBehaviour
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

    public Transform explode;

    private void Awake()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Layers == (Layers | (1 << collision.gameObject.layer)))
        {
            D2dDestructible.StampAll(transform.position, Size*transform.localScale, Angle, StampTex, Hardness, Layers);
            Transform instance = Instantiate(explode,transform.position,transform.rotation);
            instance.localScale = transform.localScale * Size;
            Destroy(instance.gameObject, 1);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Transform instance = Instantiate(explode, transform.position, transform.rotation);
        instance.localScale = transform.localScale * Size;
        Destroy(instance.gameObject, 1);
    }
}
