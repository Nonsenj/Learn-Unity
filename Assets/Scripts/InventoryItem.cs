using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // drag n drop in ScreenSpace Camera 
    [Header("UI")]
    public Image image;
    public RectTransform m_transform;
    public Text countText;

    //Now, only Plant not tool
    [HideInInspector] public PlantObject item;
    [HideInInspector] public int count = 11;
    [HideInInspector] public Transform parentAfterDrag;

    public void InitialiseItem(PlantObject newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();

    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }

    private void Start()
    {
        m_transform = GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
        Vector3 vec = Camera.main.WorldToScreenPoint(m_transform.position);
        vec.x += eventData.delta.x;
        vec.y += eventData.delta.y;
        m_transform.position = Camera.main.ScreenToWorldPoint(vec);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("BeginDrag");
        parentAfterDrag = transform.parent;
        m_transform.SetParent(transform.root);
        m_transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("EndDrag");
        m_transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
