using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Create_object : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler 
{
    [SerializeField] public GameObject prefab; // Reference to the prefab to instantiate
    [SerializeField] public string objectName;
    private GameObject draggingObject;
    private Canvas canvas;
    private TextMeshProUGUI text_limit;

    private menegment manager;
        void Awake()
    {
        manager = GameObject.Find("level_manager").GetComponent<menegment>();
        canvas = GetComponentInParent<Canvas>();
        text_limit = transform.Find("limit").gameObject.GetComponent<TextMeshProUGUI>();
        UpdateText();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Create a temporary object to represent the dragging prefab
        draggingObject = Instantiate(prefab, transform.position, Quaternion.identity);
        draggingObject.GetComponent<Collider2D>().enabled = false; // Disable collider to avoid interaction during drag
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Move the dragging object with the mouse
        Vector3 screenPosition = Input.mousePosition;
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPosition, eventData.pressEventCamera, out localPoint);
        draggingObject.transform.position = canvas.transform.TransformPoint(localPoint);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!manager.check_limit(objectName))
        {
            Destroy(draggingObject);
        }
        else 
        {
            draggingObject.GetComponent<Collider2D>().enabled = true; // Enable collider after drop
            manager.AddObject(objectName, 1);
            UpdateText();
        }

        
    }
    public void UpdateText()
    {
        text_limit.text = manager.GetText(objectName);
    }
    

    
}
