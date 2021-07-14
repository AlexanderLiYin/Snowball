using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    RectTransform rectTransform;
    Vector3 originPos;
    CanvasGroup canvasGroup;
    Color color;

    public GameObject building;
    public EnergyDisplay energy;
    public int cost = 40;

    [SerializeField] private Canvas canvas; // Used to scale drag incase canvas gets rescaled
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originPos = rectTransform.position;
        canvasGroup = GetComponent<CanvasGroup>();
        color = gameObject.GetComponent<Image>().color;
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
        if (!CanSpawnBuilding(building, mouseLocation))
        {
            gameObject.GetComponent<Image>().color = new Color(1, 0, 0, 1);
            print("Is being called");
        }
        else
            gameObject.GetComponent<Image>().color = color;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        Vector3 mouseLocation = GetMouseWorldPosition();
        if(CanSpawnBuilding(building,mouseLocation) && energy.decEnergy(cost))
            Instantiate(building, mouseLocation, Quaternion.identity);

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

    bool CanSpawnBuilding(GameObject build, Vector3 position)
    {
        BoxCollider2D buildingBoxCollider = build.GetComponent<BoxCollider2D>();
        if (Physics2D.OverlapBox(position + (Vector3)buildingBoxCollider.offset, buildingBoxCollider.size, 0))
            return false;
        else return true;
    }
}
