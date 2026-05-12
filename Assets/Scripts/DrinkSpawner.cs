using UnityEngine;

public class DrinkSpawner : MonoBehaviour
{
    public Transform drinkSpawnPoint;

    // Sound
    public AudioSource audioSource;
    public AudioClip spawnSound;

    private GameObject currentDrink;

    public void SpawnDrink(GameObject drinkPrefab)
    {
        // Remove previous drink
        if (currentDrink != null)
        {
            Destroy(currentDrink);
        }

        // Spawn new drink
        currentDrink = Instantiate(
            drinkPrefab,
            drinkSpawnPoint.position,
            drinkSpawnPoint.rotation
        );

        // Parent it so it moves with the spawn point
        currentDrink.transform.SetParent(drinkSpawnPoint);

        // Play spawn sound
        if (audioSource != null && spawnSound != null)
        {
            audioSource.PlayOneShot(spawnSound);
        }
    }
}