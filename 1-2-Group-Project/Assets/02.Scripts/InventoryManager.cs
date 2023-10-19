using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inst;

    Slot[] inventorySlots;

    public Transform innerPanelTransform;

    public GameObject itemPrefab; // ���� �̸��� �����ϰ� ����� ������� �����ϰ� ����

    public Text goldText;

    void Start()
    {
        inst = this;

        inventorySlots = innerPanelTransform.GetComponentsInChildren<Slot>(); // Slot Ŭ���� Ÿ������ �����ϰ� ��Ÿ ����

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
        int goldCost = 150; // ���� ����� 150���� ���� (���ϴ� �������� ���� ����)

        int currentGold = GameManager.Instance.GetGold();

        if (currentGold >= goldCost)
        {
            GameObject[] emptySlots = GetEmptyInventorySlot();

            if (emptySlots != null)
            {
                int randomNum = UnityEngine.Random.Range(0, emptySlots.Length);

                var item = Instantiate(itemPrefab, emptySlots[randomNum].transform.position, Quaternion.identity);
                item.GetComponent<Item>().SetItem(1, emptySlots[randomNum].transform); // SetItem ȣ�� �ÿ� �ùٸ� �Ķ���� ����

                // �Ҹ�� ��常ŭ ����
                GameManager.Instance.SpendGold(goldCost);
            }
        }
        else
        {
            Debug.Log("��尡 �����մϴ�! (150��� �ʿ�)");
        }
    }

    public void CreateUpgradeItem(int newNumber, Transform newParent)
    {
        var item = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity); // Vector3 ��Ÿ ����
        item.GetComponent<Item>().SetItem(newNumber, newParent);
    }

    void UpdateGoldText(int newGoldValue)
    {
        goldText.text = newGoldValue.ToString();
    }
}
