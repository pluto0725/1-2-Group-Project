using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inst;

    Slot[] inventorySlots;

    public Transform innerPanelTransform;

    public GameObject itemPrefab; // 변수 이름을 통일하고 선언된 변수명과 동일하게 변경

    void Start()
    {
        inst = this;

        inventorySlots = innerPanelTransform.GetComponentsInChildren<Slot>(); // Slot 클래스 타입으로 변경하고 오타 수정
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
            item.GetComponent<Item>().SetItem(1, emptySlots[randomNum].transform); // SetItem 호출 시에 올바른 파라미터 전달
        }
    }

    public void CreateUpgradeItem(int newNumber, Transform newParent)
    {
        var item = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity); // Vector3 오타 수정
        item.GetComponent<Item>().SetItem(newNumber, newParent);
    }
}
