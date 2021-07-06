using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    private RectTransform origin;
    private CanvasGroup canvasGroup;

    [SerializeField] private Canvas canvas; // Used to scale drag incase canvas gets rescaled
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        origin = rectTransform;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("On Pointer Down");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        print("On Begin Drag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        print("On Drag");
        rectTransform.anchoredPosition += eventData.delta * canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("On End Drag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        print("On Drop");
        rectTransform = origin;
    }
}
