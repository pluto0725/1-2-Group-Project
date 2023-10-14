using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject beingDraggedItem;

    Vector3 startPosition;

    Transform onDragParent; // ���� �̸� ��Ÿ ����

    [HideInInspector] public Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        beingDraggedItem = gameObject; // ���� �̸� ��Ÿ ����

        startPosition = transform.position;
        startParent = transform.parent;

        GetComponent<CanvasGroup>().blocksRaycasts = false;

        transform.SetParent(onDragParent); // ���� �̸� ��Ÿ ����
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        beingDraggedItem = null; // ���� �̸� ��Ÿ ����
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (transform.parent == onDragParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
