using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lanceur : MonoBehaviour
{
    GameObject a;
    public string shotInput;
    public GameObject bombe;
    public GameObject bombeFrag;
    public Transform fleche;
    public float rotationSpeed = 10.0f;
    public float timepowerMax = 5;
    public float maxpower = 10;
    public Image bar;

    private float rotationSpeedSign = 1f;
    private bool isCharging;
    private float timerPower;

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
        if (isCharging && timerPower < timepowerMax)
        {
            timerPower += Time.deltaTime;
            bar.fillAmount = timerPower / timepowerMax;
        }

        if (Input.GetButtonDown(shotInput))
            isCharging = true;

        if (Input.GetButtonUp(shotInput))
        {
            isCharging = false;
            bar.fillAmount = 0;
            Shoot();
            timerPower = 0;
        }

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
        else if(angle <= -30)
        {
            rotationSpeedSign = 1f;
        }

    }

    void Shoot()
    {
        Vector2 velocity = Vector2.Lerp((fleche.position - transform.position).normalized, (fleche.position - transform.position).normalized * maxpower, timerPower / timepowerMax);

        GameObject instance = Instantiate(bombe, a.transform.position,transform.rotation);
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        rb.velocity += velocity;
        Destroy(instance, 5);
    }

}
