using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [Header("Main Food Prefabs")]
    public GameObject burgerPrefab;
    public GameObject hotDogPrefab;
    public GameObject pizzaPrefab;
    public GameObject kebabPrefab;
    public GameObject tacoPrefab;
    public GameObject chickenPrefab;

    [Header("Spawn Point")]
    public Transform spawnPoint;

    public void SpawnBurger()
    {
        SpawnItem(burgerPrefab, "Burger");
    }

    public void SpawnHotDog()
    {
        SpawnItem(hotDogPrefab, "Hot Dog");
    }

    public void SpawnPizza()
    {
        SpawnItem(pizzaPrefab, "Pizza");
    }

    public void SpawnKebab()
    {
        SpawnItem(kebabPrefab, "Kebab");
    }

    public void SpawnTaco()
    {
        SpawnItem(tacoPrefab, "Taco");
    }

    public void SpawnChicken()
    {
        SpawnItem(chickenPrefab, "Muslito Pollo");
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
                foodItem.category = "Main";
            }
        }
        else
        {
            Debug.LogWarning("Prefab or spawn point is missing!");
        }
    }
}
