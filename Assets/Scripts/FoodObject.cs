using UnityEngine;

public class FoodObject : MonoBehaviour
{
    public string itemName;
    public float price;

    private bool addedToCart = false;

    // Function for when food item is brought to the cart's corresponding trigger zone then removed
    private void OnTriggerEnter(Collider other)
    {
        if (addedToCart) return;

        CheckoutZone zone = other.GetComponent<CheckoutZone>();

        if (zone != null)
        {
            addedToCart = true;

            zone.cartManager.AddItem(itemName, price);

            Destroy(gameObject);
        }
    }
}