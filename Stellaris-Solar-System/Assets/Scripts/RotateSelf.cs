using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using Unity.VisualScripting;
using UnityEngine;

public class RotateSelf : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] private GameObject[] planets = new GameObject[5];
    
    private void Start()
    {
        float random;
        foreach (var planet in planets)
        {
            random = UnityEngine.Random.Range(-30f, 30f);
            planet.transform.Rotate(random,0,random);
        }
    }

    void Update()
    {
        transform.Rotate(0,rotationSpeed*Time.deltaTime,0);
    }
}
