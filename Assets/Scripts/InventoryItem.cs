using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public RectTransform m_transform;
    [HideInInspector] public Transform parentAfterDrag;

    void Start()
    {
        m_transform = GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        Vector3 vec = Camera.main.WorldToScreenPoint(m_transform.position);
        vec.x += eventData.delta.x;
        vec.y += eventData.delta.y;
        m_transform.position = Camera.main.ScreenToWorldPoint(vec);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("BeginDrag");
        parentAfterDrag = transform.parent;
        m_transform.SetParent(transform.root);
        m_transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        m_transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
