using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using Vector3 = UnityEngine.Vector3;

public class PlanetOrbit : MonoBehaviour
{
    private GameObject sun;
    [Header("Connections")]
    [SerializeField] private GameObject moon = null;
    
    [Header("Wobble Controls")]
    [SerializeField] private float wobbleAmount;
    [SerializeField] private float wobbleSpeed;
    
    [Header("Orbit Controls")]
    [SerializeField] private float orbitSpeed = 40;

    private void Start()
    {
        sun = transform.parent.gameObject;
        float distance = Vector3.Distance(sun.transform.position, transform.position);
        orbitSpeed *= 10*(1/distance);
    }

    void Update()
    {
        Vector3 Axis = new Vector3();
        //if (Axis.x != 0) Axis.x = (float)(sun.transform.up.x * (1/sun.transform.up.x));
        Axis.y = (float)(sun.transform.up.y * (1/sun.transform.up.y));
        //if (Axis.z != 0) Axis.z = (float)(sun.transform.up.z * (1/sun.transform.up.z));
        transform.RotateAround(sun.transform.position,Axis,orbitSpeed*Time.deltaTime);

        if (CompareTag("Wobbles") && wobbleAmount != 0 && wobbleSpeed != 0)
        {
            Vector3 v = transform.position;
            transform.position = new Vector3(v.x,((float)Math.Sin(Time.timeAsDouble*wobbleSpeed)*wobbleAmount+(wobbleAmount/2)),v.z);
        }
    }
}
