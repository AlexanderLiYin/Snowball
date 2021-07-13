using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpellDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    protected RectTransform rectTransform;
    protected Vector3 originPos;
    protected CanvasGroup canvasGroup;
    public GameObject spell;

    [SerializeField] private Canvas canvas; // Used to scale drag incase canvas gets rescaled

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originPos = rectTransform.position;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false; // So functions below the icon can use OnDrop
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta * canvas.scaleFactor;
        Vector3 mouseLocation = GetMouseWorldPosition();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        Vector3 mouseLocation = GetMouseWorldPosition();
        Instantiate(spell, mouseLocation, Quaternion.identity);
        canvasGroup.blocksRaycasts = true;
        rectTransform.position = originPos; // Return icon to it's orginal location
    }

    public void OnDrop(PointerEventData eventData)
    {

    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
