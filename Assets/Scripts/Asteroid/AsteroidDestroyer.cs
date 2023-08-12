using UnityEngine;

/// <summary>
/// This script is responsible for destroying asteroids that enter a specific trigger area.
/// </summary>
[RequireComponent(typeof(BoxCollider))]
public class AsteroidDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            DisableAsteroid(other.gameObject);
        }
    }

    /// <summary>
    /// Disables the specified asteroid GameObject in pool process.
    /// </summary>
    /// <param name="obj">The asteroid GameObject to be destroyed.</param>
    private void DisableAsteroid(GameObject obj)
    {
        if (obj.CompareTag("Asteroid"))
        {
            // Deactivate the asteroid GameObject, removing it from the scene.
            obj.gameObject.SetActive(false);
            // Additional actions here.
        }
    }
}
