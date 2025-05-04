using System.Collections.Generic;
using UnityEngine;

public class TrayZone : MonoBehaviour
{
    public List<FoodItem> itemsOnTray = new List<FoodItem>();

    void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<FoodItem>();
        if (item && !itemsOnTray.Contains(item))
        {
            Debug.Log("➕ Item entered tray: " + item.itemName);
            itemsOnTray.Add(item);
        }
    }


    void OnTriggerExit(Collider other)
    {
        var item = other.GetComponent<FoodItem>();
        if (item && itemsOnTray.Contains(item))
        {
            Debug.Log("➖ Item exited tray: " + item.itemName);
            itemsOnTray.Remove(item);
        }
    }

}
