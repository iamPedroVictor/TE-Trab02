﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Starfield : MonoBehaviour
{

    public int maxStars = 1000;
    public int universeSize = 10;

    [SerializeField]
    private ParticleSystem.Particle[] points;
    [SerializeField]
    private ParticleSystem particleSystem;

    private void Create()
    {

        points = new ParticleSystem.Particle[maxStars];

        for (int i = 0; i < maxStars; i++)
        {
            points[i].position = Random.insideUnitSphere * universeSize;
            points[i].startSize = Random.Range(0.05f, 0.05f);
            points[i].startColor = new Color(1, 1, 1, 1);
        }

        particleSystem = gameObject.GetComponent<ParticleSystem>();

        particleSystem.SetParticles(points, points.Length);

    }

    void Start()
    {
        Create();
    }

}
