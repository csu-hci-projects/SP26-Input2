using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class CartManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI cartText;

    [Header("Bag")]
    public GameObject bagPrefab;
    public Transform bagSpawnPoint;

    private List<string> items = new List<string>();
    private float total = 0f;

    private GameObject currentBag;

    void Start()
    {
        UpdateUI();
    }
    
    // Adds items to the cart
    public void AddItem(string itemName, float price)
    {
        items.Add(itemName);
        total += price;

        UpdateUI();
    }
    // Function that displays items or lack thereof in the cart
    void UpdateUI()
    {
        cartText.text = "Cart:\n";

        if (items.Count == 0)
        {
            cartText.text += "(Empty)\n";
        }
        else
        {
            foreach (string item in items)
            {
                cartText.text += "- " + item + "\n";
            }
        }

        cartText.text += "\nTotal: $" + total.ToString("F2");
    }
    
    // Checkout function that spawns the box/bag
    public void Checkout()
    {
        if (currentBag != null)
        {
            Destroy(currentBag);
        }

        currentBag = Instantiate(
            bagPrefab,
            bagSpawnPoint.position,
            bagSpawnPoint.rotation
        );
    }

    // Clear Cart function
    public void ClearCart()
    {
        items.Clear();
        total = 0f;

        if (currentBag != null)
        {
            Destroy(currentBag);
        }

        UpdateUI();
    }
}