using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject beingDraggedItem;

    Vector3 startPosition;

    Transform onDragParent; // 변수 이름 오타 수정

    [HideInInspector] public Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        beingDraggedItem = gameObject; // 변수 이름 오타 수정

        startPosition = transform.position;
        startParent = transform.parent;

        GetComponent<CanvasGroup>().blocksRaycasts = false;

        transform.SetParent(onDragParent); // 변수 이름 오타 수정
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        beingDraggedItem = null; // 변수 이름 오타 수정
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
