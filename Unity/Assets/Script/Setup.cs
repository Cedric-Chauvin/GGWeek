using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour
{
    public static float maxAngle = 30;
    public static float minAngle = -30;
    public static float rotationSpeed=1;
    public static float timeMaxNormal=5;
    public static float minPowerNormal=5;
    public static float maxPowerNormal=20;
    public static float loadTimeNormal;
    public static float timeMaxFrag=5;
    public static float minPowerFrag=5;
    public static float maxPowerFrag=20;
    public static float loadTimeFrag;

    public float MaxAngle = 30;
    public float MinAngle = -30;
    public float RotationSpeed = 1;
    public float TimeMaxNormal = 5;
    public float MinPowerNormal = 5;
    public float MaxPowerNormal = 20;
    public float LoadTimeNormal;
    public float TimeMaxFrag = 5;
    public float MinPowerFrag = 5;
    public float MaxPowerFrag = 20;
    public float LoadTimeFrag;

    private void Awake()
    {
        maxAngle = MaxAngle;
        minAngle = MinAngle;
        rotationSpeed = RotationSpeed;
        timeMaxNormal = TimeMaxNormal;
        minPowerNormal = MinPowerNormal;
        maxPowerNormal = MaxPowerNormal;
        loadTimeNormal = LoadTimeNormal;
        timeMaxFrag = TimeMaxFrag;
        minPowerFrag = MinPowerFrag;
        maxPowerFrag = MaxPowerFrag;
        loadTimeFrag = LoadTimeFrag;
    }

}
