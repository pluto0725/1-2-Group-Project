
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inst;

    Slot[] inventorySlots;
    public Transform innerPanelTransform;
    public GameObject itemPrefab;
    public Text goldText;

    void Start()
    {
        inst = this;

        inventorySlots = innerPanelTransform.GetComponentsInChildren<Slot>();

        GameManager.Instance.OnGoldChanged += UpdateGoldText;
        UpdateGoldText(GameManager.Instance.GetGold());
    }

    GameObject[] GetEmptyInventorySlot()
    {
        List<GameObject> emptySlots = new List<GameObject>();

        foreach (Slot s in inventorySlots)
        {
            if (s.item == null)
                emptySlots.Add(s.gameObject);
        }
        if (emptySlots.Count == 0)
            return null;
        else
            return emptySlots.ToArray();
    }

    public void CreateItem()
    {
        int goldCost = 150;

        int currentGold = GameManager.Instance.GetGold();

        if (currentGold >= goldCost)
        {
            GameObject[] emptySlots = GetEmptyInventorySlot();

            if (emptySlots != null)
            {
                int randomNum = Random.Range(0, emptySlots.Length);

                var item = Instantiate(itemPrefab, emptySlots[randomNum].transform.position, Quaternion.identity);
                item.GetComponent<Item>().SetItem(1, emptySlots[randomNum].transform);

                GameManager.Instance.SpendGold(goldCost);
            }
        }
        else
        {
            Debug.Log("골드가 부족합니다! (150골드 필요)");
        }
    }

    public void CreateUpgradeItem(int newNumber, Transform newParent)
    {
        var item = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
        item.GetComponent<Item>().SetItem(newNumber, newParent);
    }

    void UpdateGoldText(int newGoldValue)
    {
        if (goldText != null)
        {
            goldText.text = newGoldValue.ToString();
        }
    }
}
