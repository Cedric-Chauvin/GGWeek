using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public SpriteRenderer shield;
    public Collider2D shieldCollider;
    private bool visible;

    // Start is called before the first frame update
    void Start()
    {
        shield = GetComponent<SpriteRenderer>();
        shieldCollider = GetComponent<Collider2D>();
        visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            shield.enabled = !shield.enabled;
            shieldCollider.enabled = !shieldCollider.enabled;
        }
    }
}
