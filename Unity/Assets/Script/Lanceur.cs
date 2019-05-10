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
    GameObject b;

    public PLAYER player;
    public GameObject bombe;
    public GameObject bombeFrag;
    public Transform fleche;
    public Image chargeBar;
    public Image energieBar;
    public Image malusBar;
    public Transform shield;
    public Transform fumée;

    private float rotationSpeedSign = 1f;
    private bool isCharging;
    private float timerPower;
    private PlayerInput input = new PlayerInput();

    private float angleMax;
    private float angleMin;

    private bool useMulti;
    private bool isEnergie;
    private bool needRepair;
    private CHARGESTATE button;
    private float energie;
    private float timerInput;
    private float malusAmont;

    private bool shielded;
    private float initPosShield;
    private float timerMur;

    private Animator anim;

    private void Awake()
    {
        a = fleche.transform.Find("a").gameObject;
        initPosShield = shield.position.y;
        anim = gameObject.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        input.Fire = player.ToString() + "Fire";
        input.Multi = player.ToString() + "Multi";
        input.Shield = player.ToString() + "Shield";
        input.Fix1 = player.ToString() + "Fix1";
        input.Fix2 = player.ToString() + "Fix2";

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

        Fix();
        if (energie > 0)
        {
            Fire();
            Shield();
            malusBar.fillAmount = 0;
        }
        else
        {
            malusBar.fillAmount = energie / malusAmont;

        }

        RotationFleche();
    }

    private void Shield()
    {
        if (shield && timerMur < Setup.timeMur)
            timerMur += Time.deltaTime;

        if (Input.GetButtonDown(input.Shield)&&!shielded)
        {
            shielded = true;
            timerMur = 0;
            Transform fume = Instantiate(fumée);
            Destroy(fume.gameObject, 0.3f);
            energie -= Setup.energiecons;
            if (energie < 0)
            {
                energie = energie * Setup.malusEnergie;
                malusAmont = energie;
            }
        }


        if (shielded && shield.position.y <= Setup.hauteurMur + initPosShield)
            shield.Translate(0, Setup.speedMur * Time.deltaTime, 0);

        if (timerMur > Setup.timeMur)
            shielded = false;
        if (!shielded && shield.position.y >=  initPosShield)
            shield.Translate(0, -Setup.speedMur * Time.deltaTime, 0);
    }

    private void Fix()
    {
        if (isEnergie && timerInput < Setup.timeInput)
        {
            timerInput += Time.deltaTime;
        }

        if(timerInput> Setup.timeInput)
        {
            isEnergie = false;
            button = CHARGESTATE.NOBUT;
        }


        if (Input.GetButtonDown(input.Fix1) && button != CHARGESTATE.BUT2)
        {
            if (!isEnergie)
            {
                isEnergie = true;
                timerInput = 0;
            }

            button = CHARGESTATE.BUT2;
            energie += Setup.energieSpeed;

        }else if (Input.GetButtonDown(input.Fix2) && button != CHARGESTATE.BUT1)
        {
            if (!isEnergie)
            {
                isEnergie = true;
                timerInput = 0;
            }

            button = CHARGESTATE.BUT1;
            energie += Setup.energieSpeed;
        }
        if (energie >= 100)
            energie = 100;

        energieBar.fillAmount = energie / 100;
    }


    private void Fire()
    {
        if (Input.GetButtonDown(input.Multi))
            useMulti = true;

        if (Input.GetButtonDown(input.Fire))
            isCharging = true;

        if (isCharging && timerPower < Setup.timeMaxNormal)
        {
            timerPower += Time.deltaTime;
            chargeBar.fillAmount = timerPower / Setup.timeMaxNormal;
        }



        if (Input.GetButtonUp(input.Fire))
        {
            isCharging = false;
            chargeBar.fillAmount = 0;
            Shoot(bombe);
            timerPower = 0;
        }
    }

    private void RotationFleche()
    {
        fleche.Rotate(Vector3.forward, Setup.rotationSpeed * rotationSpeedSign);

        float angle = fleche.eulerAngles.z;

        if (angle >= 180)
        {
            angle -= 360;
        }

        if (angle >= angleMax)
        {
            rotationSpeedSign = -1f;
        }
        else if (angle <= angleMin)
        {
            rotationSpeedSign = 1f;
        }
    }

    void Shoot(GameObject bombe)
    {
        anim.SetTrigger("Shot");
        Vector2 velocity = (-fleche.position +a.transform.position).normalized * Setup.power;
        GameObject instance;
        if (useMulti)
        {
            instance = Instantiate(bombeFrag, a.transform.position, transform.rotation);
            energie -= (timerPower / Setup.timeMaxNormal) * Setup.maxEnergieFrag;
            useMulti = false;
        }
        else
        {
            instance = Instantiate(bombe, a.transform.position, transform.rotation);
            energie -= (timerPower / Setup.timeMaxNormal) * Setup.maxEnergieNormal;
        }
        if (energie < 0)
        {
            energie = energie * Setup.malusEnergie;
            malusAmont = energie;
        }
        instance.transform.localScale = instance.transform.localScale * ((timerPower / Setup.timeMaxNormal)+0.5f);
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        rb.velocity += velocity;
        Destroy(instance, 5);
    }



    private class PlayerInput
    {
        public string Fire;
        public string Multi;
        public string Shield;
        public string Fix1;
        public string Fix2;
    }


    private enum CHARGESTATE
    {
        BUT1,
        BUT2,
        NOBUT
    }



}
