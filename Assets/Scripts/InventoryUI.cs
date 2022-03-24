using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory;
    InventorySlot[] inventorySlots;
    public GameObject inventoryUI;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        inventorySlots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.B))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < inventory.itemStacks.Count)
            {
                inventorySlots[i].AddItem(inventory.itemStacks[i]);
            }
            else
            {
                inventorySlots[i].ClearSlot();
            }
        }
    }
}
