using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inst;

    Slot[] inventorySlots;

    public Transform innerPanelTransform;

    public GameObject itemPrefab; // ���� �̸��� �����ϰ� ����� ������� �����ϰ� ����

    void Start()
    {
        inst = this;

        inventorySlots = innerPanelTransform.GetComponentsInChildren<Slot>(); // Slot Ŭ���� Ÿ������ �����ϰ� ��Ÿ ����
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
        GameObject[] emptySlots = GetEmptyInventorySlot();
        

        if (emptySlots != null)
        {
            int randomNum = UnityEngine.Random.Range(0, emptySlots.Length);

            var item = Instantiate(itemPrefab, emptySlots[randomNum].transform.position, Quaternion.identity);
            item.GetComponent<Item>().SetItem(1, emptySlots[randomNum].transform); // SetItem ȣ�� �ÿ� �ùٸ� �Ķ���� ����
        }
    }

    public void CreateUpgradeItem(int newNumber, Transform newParent)
    {
        var item = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity); // Vector3 ��Ÿ ����
        item.GetComponent<Item>().SetItem(newNumber, newParent);
    }
}
