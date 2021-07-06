using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas; // Used to scale drag incase canvas gets rescaled
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("On Pointer Down");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        print("On Begin Drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        print("On Drag");
        rectTransform.anchoredPosition += eventData.delta * canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("On End Drag");
    }

    public void OnDrop(PointerEventData eventData)
    {
        print("On Drop");
    }
}
