using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public AudioSource audioSource;
    public AudioClip spawnSound;

    private GameObject currentFood;
  
    // Spawns the food at the target spawn point while removing food if already present
    public void SpawnFood(GameObject foodPrefab)
    {
        if (currentFood != null)
        {
            Destroy(currentFood);
        }

        currentFood = Instantiate(foodPrefab, spawnPoint.position, spawnPoint.rotation);
        currentFood.transform.SetParent(spawnPoint);

        StartCoroutine(ScaleUp(currentFood));
       
        // Spawn sound
        if (audioSource != null && spawnSound != null)
        {
            audioSource.PlayOneShot(spawnSound);
        }
    }
    // Scales the food onto the plate when spawning for a different look
    IEnumerator ScaleUp(GameObject obj)
    {
        float time = 0f;
        float duration = 0.2f;

        Vector3 targetScale = obj.transform.localScale;
        obj.transform.localScale = Vector3.zero;

        while (time < duration)
        {
            time += Time.deltaTime;
            obj.transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, time / duration);
            yield return null;
        }

        obj.transform.localScale = targetScale;
    }
}