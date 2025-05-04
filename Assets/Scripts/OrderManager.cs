using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderManager : MonoBehaviour
{
    [Header("Order Display")]
    public TMP_Text orderDisplay;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip incorrectSound;

    [Header("Tray")]
    public TrayZone trayZone;

    private List<List<string>> orders = new List<List<string>>();
    private int currentOrderIndex = 0;

    private void Start()
    {
        GenerateOrders();
        DisplayCurrentOrder();
    }

    void GenerateOrders()
    {
        orders.Clear();
        for (int i = 0; i < 10; i++) // generate 10 random orders
        {
            List<string> newOrder = new List<string>();

            newOrder.Add(GetRandomItem(mainFoods));
            newOrder.Add(GetRandomItem(complementaries));
            newOrder.Add(GetRandomItem(drinks));

            orders.Add(newOrder);
        }
    }

    void DisplayCurrentOrder()
    {
        if (currentOrderIndex >= orders.Count)
        {
            orderDisplay.text = "🎉 All Orders Completed!";
            return;
        }

        var currentOrder = orders[currentOrderIndex];
        orderDisplay.text = "Order:\n" + string.Join("\n", currentOrder);
    }

    public void SubmitOrder()
    {
        Debug.Log("SubmitOrder called");

        if (trayZone == null)
        {
            Debug.LogError("TrayZone is not assigned!");
            return;
        }

        CheckOrder();
    }


    void CheckOrder()
    {
        List<string> trayItems = new List<string>();

        foreach (var item in trayZone.itemsOnTray)
        {
            if (item != null)
                trayItems.Add(item.itemName);
        }

        var expectedOrder = orders[currentOrderIndex];

        bool match = trayItems.Count == expectedOrder.Count &&
                     new HashSet<string>(trayItems).SetEquals(expectedOrder);

        Debug.Log("Tray items: " + string.Join(", ", trayItems));
        Debug.Log("Expected items: " + string.Join(", ", expectedOrder));
        Debug.Log("Match result: " + match);

        if (match)
        {
            Debug.Log("✅ Correct order!");
            audioSource?.PlayOneShot(incorrectSound);
            ClearTray();
            currentOrderIndex++;
            DisplayCurrentOrder();
        }
        else
        {
            Debug.Log("❌ Wrong order!");
            audioSource?.PlayOneShot(correctSound);
            StopAllCoroutines();
            StartCoroutine(TryAgainMessageRoutine());
        }
    }



    IEnumerator TryAgainMessageRoutine()
    {
        string orderText = "Order:\n" + string.Join("\n", orders[currentOrderIndex]);
        orderDisplay.text = "❌ Incorrect! Try Again";
        yield return new WaitForSeconds(2f);
        orderDisplay.text = orderText;
    }

    void ClearTray()
    {
        foreach (var item in trayZone.itemsOnTray)
        {
            if (item != null)
                Destroy(item.gameObject);
        }
        trayZone.itemsOnTray.Clear();
    }

    // Sample data
    private List<string> mainFoods = new List<string> {
        "Burger", "Hot Dog", "Pizza", "Kebab", "Taco", "Chicken"
    };

    private List<string> complementaries = new List<string> {
        "French Fries", "Nuggets", "Helado", "Salad"
    };

    private List<string> drinks = new List<string> {
        "Red-Cola", "Astro Pop", "Candy Fresh", "Chum Shake"
    };

    string GetRandomItem(List<string> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}
