using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanceur : MonoBehaviour
{
    GameObject a;
    public GameObject bombe;
    public Transform fleche;
    Vector3 initPos;

    private void Awake()
    {
        a = transform.Find("a").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        initPos = fleche.position + new Vector3(-1.5f,0,0) ;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();

        if (Input.GetButton("Vertical"))
        {
            if(Input.GetAxis("Vertical")>0)
                fleche.RotateAround(initPos, Vector3.forward, 10);
            else
                fleche.RotateAround(initPos, Vector3.forward, -10);
        }
    }

    void Shoot()
    {
        Instantiate(bombe, a.transform.position, transform.rotation);
    }

}
