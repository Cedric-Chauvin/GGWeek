using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lanceur : MonoBehaviour
{
    public enum PLAYER
    {
        P1,
        P2
    }

    GameObject a;

    public PLAYER player;
    public GameObject bombe;
    public GameObject bombeFrag;
    public Transform fleche;
    public Image bar;

    private float rotationSpeedSign = 1f;
    private bool isCharging;
    private float timerPower;
    private PlayerInput input = new PlayerInput();

    private float angleMax;
    private float angleMin;

    private void Awake()
    {
        a = fleche.transform.Find("a").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        input.Fire1 = player.ToString() + "Fire1";
        input.Fire2 = player.ToString() + "Fire2";
        input.Shield = player.ToString() + "Shield";
        input.Energie = player.ToString() + "Energie";
        input.Fix = player.ToString() + "Fix";

        angleMax = Setup.maxAngle;
        angleMin = Setup.minAngle;

        if (player == PLAYER.P2)
        {
            angleMax = -Setup.minAngle;
            angleMin = -Setup.maxAngle;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isCharging && timerPower < Setup.timeMaxNormal)
        {
            timerPower += Time.deltaTime;
            bar.fillAmount = timerPower / Setup.timeMaxNormal;
        }

        if (Input.GetButtonDown(input.Fire1))
            isCharging = true;

        if (Input.GetButtonUp(input.Fire1))
        {
            isCharging = false;
            bar.fillAmount = 0;
            Shoot(bombe);
            timerPower = 0;
        }

        if (Input.GetButtonDown(input.Fire2))
            isCharging = true;

        if (Input.GetButtonUp(input.Fire2))
        {
            isCharging = false;
            bar.fillAmount = 0;
            Shoot(bombeFrag);
            timerPower = 0;
        }

        fleche.RotateAround(transform.position, Vector3.forward, Setup.rotationSpeed * rotationSpeedSign);

        float angle = fleche.eulerAngles.z;

        if (angle >= 180)
        {
            angle -= 360;
        }

        if (angle >= angleMax)
        {
            rotationSpeedSign = -1f;
        }
        else if(angle <= angleMin)
        {
            rotationSpeedSign = 1f;
        }

    }

    void Shoot(GameObject bombe)
    {
        Vector2 velocity = Vector2.Lerp((fleche.position - transform.position).normalized*Setup.minPowerNormal, (fleche.position - transform.position).normalized * Setup.maxPowerFrag, timerPower / Setup.timeMaxNormal);

        GameObject instance = Instantiate(bombe, a.transform.position,transform.rotation);
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        rb.velocity += velocity;
        Destroy(instance, 5);
    }



    private class PlayerInput
    {
        public string Fire1;
        public string Fire2;
        public string Shield;
        public string Energie;
        public string Fix;
    }
}
