using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public string itemDescription;
    public int itemCost;
    public bool itemRotate;
    public float amount; //potion add amount to player health value,
                         // weapon decrease enemy health
    public Sprite itemSprite;
    protected Inventory inventory;
    public enum rarity { legendary, rare, uncommon, common };
    public rarity itemRarity;

    SpriteRenderer itemRend;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        itemRend = GetComponent<SpriteRenderer>();
        itemRend.sprite = itemSprite;
    }

    public virtual void Use()
    {
        Debug.Log("base use");
    }

    public virtual void Remove()
    {
        inventory.RemoveItem(this);
    }
}

