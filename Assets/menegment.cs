using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menegment : MonoBehaviour
{
    [SerializeField] List<Create_object> objects_list;
    [SerializeField] List<create_with_rotate_obj> objects_list_2;
    private Dictionary<string, int> maxValueList = new Dictionary<string, int>
    {
        {"cub 1", 2}, {"cub 2", 2 }, { "cub 3", 2}
    };
    private Dictionary<string, int> currentValueList = new Dictionary<string, int>();

    public void AddObject(string key, int value)
    {
        if (currentValueList.ContainsKey(key))
        {
            currentValueList[key] += value;
        }
        else 
        {
        currentValueList.Add(key, value);
        }
        Debug.Log(currentValueList[key]);
    } 
    public bool check_limit (string key)
    {
        if (!currentValueList.ContainsKey(key) || currentValueList[key] < maxValueList[key]) 
        {
            return true;
        }
        return false;
    }
    public string GetText(string key) 
    {
        if (!currentValueList.ContainsKey(key)) 
        {
            return $"0/{maxValueList[key]}";
        }
        return $"{currentValueList[key]}/{maxValueList[key]}";
    }
    public void UpdateAllTexts()
    { 
        for(int i = 0; i < objects_list.Count; i++)
        {
            objects_list[i]?.UpdateText();
        }
        for (int i = 0; i < objects_list_2.Count; i++)
        {
            objects_list_2[i]?.UpdateText();
        }
    }
    public void restart_level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
