using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class remove_object : MonoBehaviour
{ [SerializeField] GameObject object_to_remove;
    private menegment manager;
    [SerializeField] string objName;
    void Awake()
    {
        manager = GameObject.Find("level_manager").GetComponent<menegment>();
    }
        public void remove_objects() 
    {
        Destroy(object_to_remove);
        manager?.AddObject(objName, -1);
        manager.UpdateAllTexts();

    }
}
