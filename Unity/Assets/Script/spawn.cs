using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{

    public float rate;
    public GameObject[] mongol;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", rate, rate);
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(mongol[(int)Random.Range(0, mongol.Length)], new Vector3(Random.Range(14.5f, 14.5f), 4, -1), Quaternion.identity);
    }
}
