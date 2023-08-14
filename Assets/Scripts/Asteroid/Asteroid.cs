using System;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
///     Represents an asteroid with continuous movement and rotation in a space.
/// </summary>
[RequireComponent(typeof(MeshCollider), typeof(Rigidbody))]
public class Asteroid : MonoBehaviour
{
    [Header("List of possible meshes")] 
    public Mesh[] meshVariations;

    [Header("Continuous movement settings")] 
    [SerializeField] private float minMovementSpeed = 1f;
    [SerializeField] private float maxMovementSpeed = 1f;

    [Header("Continuous rotation settings")] 
    [SerializeField] private float minRotationSpeed = 50f;
    [SerializeField] private float maxRotationSpeed = 100f;
    [SerializeField] private float maxScaleDif = 1f;

    private Vector3 _rotationAxis;
    private MeshFilter _meshFilter;
    private MeshCollider _meshCollider;
    private float _movementSpeed;
    private float _rotationSpeed;

    private void Awake()
    {
        // Set a random mesh variation from the list.
        _meshFilter = GetComponent<MeshFilter>();
        _meshFilter.mesh = meshVariations[Random.Range(0, meshVariations.Length)];

        // Set the mesh collider to match the selected mesh.
        _meshCollider = GetComponent<MeshCollider>();
        _meshCollider.sharedMesh = _meshFilter.mesh;

        // Randomize scale, movement speed, and rotation speed of the asteroid.
        transform.localScale *= Random.Range(1f, maxScaleDif);
        _movementSpeed = Random.Range(minMovementSpeed, maxMovementSpeed);
        _rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        _rotationAxis = Random.insideUnitSphere.normalized;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    /// <summary>
    ///     Move the asteroid backward (toward the player) in space based on the movement speed.
    /// </summary>
    private void Move()
    {
        transform.position += Vector3.back * _movementSpeed;
    }

    /// <summary>
    ///     Rotate the asteroid around its random rotation axis based on the rotation speed.
    /// </summary>
    private void Rotate()
    {
        var angle = _rotationSpeed * Time.deltaTime;
        var deltaRotation = Quaternion.AngleAxis(angle, _rotationAxis);
        transform.rotation *= deltaRotation;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 7)
        {
            if (other.gameObject.TryGetComponent<Hitable>(out Hitable hit))
            {
                hit.Hit(1);
            }
        }
    }
}