using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour
{
    public static float maxAngle = 30;
    public static float minAngle = -30;
    public static float rotationSpeed=1;
    public static float timeMaxNormal=5;
    public static float power = 5;
    public static float energieSpeed;
    public static float timeInput;
    public static float maxEnergieNormal;
    public static float maxEnergieFrag;
    public static float malusEnergie;
    public static float maxRadius;
    public static float hauteurMur;
    public static float speedMur;
    public static float timeMur;
    public static float energiecons;

    public float MaxAngle = 30;
    public float MinAngle = -30;
    public float RotationSpeed = 1;
    public float TimeMaxNormal = 5;
    public float Power = 10;
    public float EnergieSpeed;
    public float TimeInput;
    public float MaxCostEnergieNormal;
    public float MaxCostEnergieFrag;
    public float MalusEnergie;
    public float MaxRadius;
    public float HauteurMur;
    public float SpeedMur;
    public float TimeMur;
    public float Energiecons=40;

    private void Awake()
    {
        maxAngle = MaxAngle;
        minAngle = MinAngle;
        rotationSpeed = RotationSpeed;
        timeMaxNormal = TimeMaxNormal;
        power = Power;
        energieSpeed = EnergieSpeed;
        timeInput = TimeInput;
        maxEnergieNormal = MaxCostEnergieNormal;
        maxEnergieFrag = MaxCostEnergieFrag;
        malusEnergie = MalusEnergie;
        maxRadius = MaxRadius;
        hauteurMur = HauteurMur;
        speedMur = SpeedMur;
        timeMur = TimeMur;
        energiecons = Energiecons;
    }

}
