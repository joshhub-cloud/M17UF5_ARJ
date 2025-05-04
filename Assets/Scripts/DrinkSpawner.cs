using UnityEngine;

public class DrinkSpawner : MonoBehaviour
{
    [Header("Drink Prefabs")]
    public GameObject redColaPrefab;
    public GameObject astroPopPrefab;
    public GameObject candyFreshPrefab;
    public GameObject chumShakePrefab;

    [Header("Spawn Point")]
    public Transform spawnPoint;

    public void SpawnRedCola()
    {
        SpawnItem(redColaPrefab, "Red-Cola");
    }

    public void SpawnAstroPop()
    {
        SpawnItem(astroPopPrefab, "Astro Pop");
    }

    public void SpawnCandyFresh()
    {
        SpawnItem(candyFreshPrefab, "Candy Fresh");
    }

    public void SpawnChumShake()
    {
        SpawnItem(chumShakePrefab, "Chum Shaker");
    }

    private void SpawnItem(GameObject prefab, string itemName)
    {
        if (prefab != null && spawnPoint != null)
        {
            GameObject item = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            item.name = itemName;

            FoodItem foodItem = item.GetComponent<FoodItem>();
            if (foodItem != null)
            {
                foodItem.itemName = itemName;
                foodItem.category = "Drink";
            }
        }
        else
        {
            Debug.LogWarning("Prefab or spawn point is missing!");
        }
    }
}
