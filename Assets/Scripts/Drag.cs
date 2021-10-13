using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Canvas MainCanvas;
    public GameObject bounds;

    private RectTransform rectTransform;
    private Rect boundsRect;

    private void Start()
    {
        rectTransform = transform as RectTransform;
        boundsRect = bounds.GetComponent<RectTransform>().rect;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += (eventData.delta / MainCanvas.scaleFactor);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // TODO if it goes out of bounds put it in the center.

        //if (GetComponent<Renderer>().isVisible)
        //{
        //    rectTransform.anchoredPosition = Vector2.zero;
        //}

        if(!boundsRect.Contains(rectTransform.anchoredPosition))
        {
            rectTransform.anchoredPosition = Vector2.zero;
        }

    }
}
