using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanceur2 : MonoBehaviour
{
    GameObject a;
    public GameObject bombe;
    public Transform fleche;
    public float rotationSpeed = 10.0f;
    private float rotationSpeedSign = 1f;
    public int angleMin;
    public int angleMax;

    private void Awake()
    {
        a = fleche.transform.Find("a").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();

        fleche.RotateAround(transform.position, Vector3.forward, rotationSpeed * rotationSpeedSign);

        float angle = fleche.eulerAngles.z;

        if (angle >= 180)
        {
            angle -= 360;
        }

        if (angle >= 30)
        {
            rotationSpeedSign = -1f;
        }
        else if (angle <= -30)
        {
            rotationSpeedSign = 1f;
        }

        /*if (Input.GetButton("Vertical"))
        {
            if(Input.GetAxis("Vertical")>0)
                fleche.RotateAround(transform.position, Vector3.forward, 10);
            else
                fleche.RotateAround(transform.position, Vector3.forward, -10);
        }*/
    }

    void Shoot()
    {
        GameObject instance = Instantiate(bombe, a.transform.position, transform.rotation);
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        rb.velocity += new Vector2((fleche.position - transform.position).x, (fleche.position - transform.position).y) * 2;
        Destroy(instance, 5);
    }

}
