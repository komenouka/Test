using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    [SerializeField] GameObject todoPrefab; 
    [SerializeField] Transform scrollContent;

    void CreateTodo(string TasukuName)
    {
        if(string.IsNullOrEmpty(TasukuName))return;
        GameObject newTodo = Instantiate(todoPrefab, scrollContent);
        Text Nanika = newTodo.GetComponentInChildren<Text>();
        
        if (Nanika != null)
        {
            Nanika.text = TasukuName;
        }
    }
}