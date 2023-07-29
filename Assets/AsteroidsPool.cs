using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class AsteroidsPool : MonoBehaviour
{
    public Transform initialPoint;
    public GameObject asteroidObject;
    public int maxObjectsPerIteration = 3;
    public float spawnRadius = 30f;
    public bool isSpawning = false;
    public float testColliderRadius = 1.0f;

    public float interval = 2.0f;
    private float _timer = 0.0f;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > interval)
        {
            if (isSpawning)
            {
                SpawnMeteorite();
            }
            _timer = 0.0f;
        }
    }

    void SpawnMeteorite()
    {
        for (int i = 0; i < Random.Range(2, maxObjectsPerIteration); i++)
        {
            
            // random pos in volume
            Vector3 spawnPoint = GetRandomPoint();

            // collision check
            if (!Physics.CheckSphere(spawnPoint, testColliderRadius))
            {
                // spawn random meteorite
                Instantiate(asteroidObject, spawnPoint, Quaternion.identity);
            }
        }
    }

    Vector3 GetRandomPoint()
    {
        return initialPoint.position + Random.insideUnitSphere * spawnRadius;
        //float xRandom = Random.Range(_bounds.min.x, _bounds.max.x);
        //float yRandom = Random.Range(_bounds.min.y, _bounds.max.y);
        //return new Vector3(xRandom, yRandom, transform.position.z);
    }
}
