using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    [SerializeField] GameObject todoPrefab; 
    [SerializeField] Transform scrollContent;
    [SerializeField] InputField[] inputFields;

    public void ClickAddButton()
    {
        string text = inputFields[0].text;

        if (text != "") 
        {
            CreateTodo(text);
            Debug.Log("タスクが追加されました: " + text);
            inputFields[0].text = "";
        }
        else
        {
            Debug.Log("何も入力されていません！");
        }
    }

    void CreateTodo(string TasukuName)
    {
        GameObject newTodo = Instantiate(todoPrefab, scrollContent);
        Text Nanika = newTodo.GetComponentInChildren<Text>();
        if (Nanika != null)
        {
            Nanika.text = TasukuName;
        }
    }
}