using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    protected RectTransform rectTransform;
    protected Vector3 origin;
    protected CanvasGroup canvasGroup;

    [SerializeField] private Canvas canvas; // Used to scale drag incase canvas gets rescaled
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        origin = rectTransform.position;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta * canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        rectTransform.position = origin;
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }
}
