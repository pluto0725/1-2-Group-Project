using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            DragManager.beingDraggedItem.transform.SetParent(transform);
        }
        else
        {
            Item dragItem = DragManager.beingDraggedItem.GetComponent<Item>(); // 변수 이름 수정
            Item slotItem = item.GetComponent<Item>(); // 변수 이름 수정

            if (dragItem.number == slotItem.number)
            {
                int backupNum = dragItem.number; // 변수 이름 수정
                Destroy(dragItem.gameObject);
                Destroy(slotItem.gameObject);

                InventoryManager.inst.CreateUpgradeItem(backupNum + 1, transform);
            }
            else
            {
                DragManager.beingDraggedItem.transform.SetParent(transform);
                item.transform.SetParent(DragManager.beingDraggedItem.GetComponent<DragManager>().startParent);
            }
        }
    }
}
