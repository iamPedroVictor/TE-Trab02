using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    private Vector3 origin = Vector3.zero;

    public float minSize, maxSize;

    public GameObject asteroids;

    public float minDistance, maxDistance;

    public void GenerateAsteroids()
    {
        float size = Random.Range(minSize, maxSize);
        GameObject asteroidClone = asteroids;

        for (var j = 0; j < 100; j++)
        {
            var pos = Random.insideUnitSphere * (minDistance + (maxDistance - minDistance) * Random.value);
            pos += origin;
            if (!Physics.CheckSphere(pos, (size / 2.0f)))
            {
                break;
            }
        }
        
    }

}
