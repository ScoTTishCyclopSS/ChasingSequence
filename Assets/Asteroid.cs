using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    public Mesh[] meshVariations;
    
    public float minMovementSpeed = 1f;
    public float maxMovementSpeed = 1f;
    public float minRotationSpeed = 50f;
    public float maxRotationSpeed = 100f;
    public float maxScaleDif = 1f;

    private Vector3 _rotationAxis;
    private MeshFilter _meshFilter;
    private MeshCollider _meshCollider;
    private float _movementSpeed;
    private float _rotationSpeed;

    private void Awake()
    {
        _rotationAxis = Random.insideUnitSphere.normalized;

        _meshFilter = GetComponent<MeshFilter>();
        _meshFilter.mesh = meshVariations[Random.Range(0, meshVariations.Length)];

        _meshCollider = GetComponent<MeshCollider>();
        _meshCollider.sharedMesh = _meshFilter.mesh;
        
        transform.localScale *= Random.Range(1f, maxScaleDif);
        _movementSpeed = Random.Range(minMovementSpeed, maxMovementSpeed);
        _rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        transform.position += Vector3.back * _movementSpeed;
    }

    void Rotate()
    {
        float angle = _rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.AngleAxis(angle, _rotationAxis);
        transform.rotation *= deltaRotation;
    }
}
