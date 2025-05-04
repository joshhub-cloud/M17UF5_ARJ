using UnityEngine;

public class ComplementaryFoodSpawner : MonoBehaviour
{
    [Header("Complementary Food Prefabs")]
    public GameObject friesPrefab;
    public GameObject nuggetsPrefab;
    public GameObject heladoPrefab;
    public GameObject saladPrefab;

    [Header("Spawn Point")]
    public Transform spawnPoint;

    public void SpawnFries()
    {
        SpawnItem(friesPrefab, "French Fries");
    }

    public void SpawnNuggets()
    {
        SpawnItem(nuggetsPrefab, "Nuggets");
    }

    public void SpawnHelado()
    {
        SpawnItem(heladoPrefab, "Helado");
    }

    public void SpawnSalad()
    {
        SpawnItem(saladPrefab, "Salad");
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
                foodItem.category = "Complementary";
            }
        }
        else
        {
            Debug.LogWarning("Prefab or spawn point is missing!");
        }
    }
}
