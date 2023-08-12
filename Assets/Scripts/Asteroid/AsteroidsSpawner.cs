using System;
using System.Collections.Generic;
using Pooling;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Manages the spawning of asteroids using an object pool.
/// </summary>
public class AsteroidsPool : MonoBehaviour
{
    [Header("Settings")]
    public Transform initialPoint;
    public int maxObjectsPerIteration = 3;
    public float spawnRadius = 30f;
    public float testColliderRadius = 1.0f;
    public float interval = 2.0f;
    
    public bool isSpawning;

    private List<Vector3> _validSpawnPoints = new List<Vector3>();
    private float _timer = 0.0f;

    private void Update()
    {
        // Increment the timer with the time elapsed since the last frame.
        _timer += Time.deltaTime;

        // Check if the timer exceeds the specified interval.
        if (_timer > interval)
        {
            // If spawning is enabled, call the SpawnMeteorites method.
            if (isSpawning)
            {
                GenerateValidSpawnPoints();
                SpawnMeteorites();
            }
            
            // Reset the timer.
            _timer = 0.0f;
        }
    }

    /// <summary>
    /// Spawns the meteorites at valid spawn positions.
    /// </summary>
    void SpawnMeteorites()
    {
        // Iterate through each valid spawn point.
        foreach (var point in _validSpawnPoints)
        {
            // Check if there is no collision at the spawn position using a sphere collider.
            if (!Physics.CheckSphere(point, testColliderRadius))
            {
                // Spawn a random meteorite from the object pool at the selected position.
                PoolingManager.instance.objectPool.Spawn("Asteroid", point, Quaternion.identity);
            }
        }
    }
    
    /// <summary>
    /// Generates a list of valid spawn points for meteorites.
    /// </summary>
    void GenerateValidSpawnPoints()
    {
        // Clear all previous points.
        _validSpawnPoints.Clear();
        
        // Generate a random number of meteorites to spawn within the specified range.
        int count = Random.Range(2, maxObjectsPerIteration);
        
        // Generate valid spawn positions for meteorites.
        int attempts = count * 10;
        while (_validSpawnPoints.Count < maxObjectsPerIteration && attempts > 0)
        {
            // Get a random position within the spawn radius around the initial point.
            Vector3 spawnPoint = GetRandomPoint();
            _validSpawnPoints.Add(spawnPoint);
            attempts--;
        }
    }

    /// <summary>
    /// Returns a random point within the spawn radius around the initial point.
    /// </summary>
    /// <returns>A random point within the specified spawn radius.</returns>
    Vector3 GetRandomPoint()
    {
        return initialPoint.position + Random.insideUnitSphere * spawnRadius;
    }
}
