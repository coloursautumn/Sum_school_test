using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Mouse_action_component : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent<GameObject> _leftButActnObj;
    [SerializeField] private UnityEvent<GameObject> _rightButActobj;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button ==PointerEventData.InputButton.Right)
        {
            _rightButActobj?.Invoke(gameObject);
        }
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            _leftButActnObj?.Invoke(gameObject);
        }
    }
}
