using UnityEngine;
using TMPro;
//using UnityEngine.UI;
public class TodoManager : MonoBehaviour
{
    [SerializeField] GameObject todoPrefab; 
    [SerializeField] Transform scrollContent;
    [SerializeField] TMP_InputField taskInput;
    //public InputField inputField;
    //public Text text;
    void Start () 
    {
    //inputField = inputField.GetComponent<InputField> ();
    //text = text.GetComponent<Text> ();
    }
    public void ClickAddButton()
    {
        string text = taskInput.text;

        if (text != "") 
        {
            CreateTodo(text);
            Debug.Log("タスクが追加されました: " + text);
            taskInput.text = "";
        }
        else
        {
            Debug.Log("何も入力されていません！");
        }
    }
    public void InputText()
    {
    　//text.text = inputField.text;
    }

    void CreateTodo(string TasukuName)
    {
        GameObject newTodo = Instantiate(todoPrefab, scrollContent);
        TMP_Text Nanika = newTodo.GetComponentInChildren<TMP_Text>();
        if (Nanika != null)
        {
            Nanika.text = TasukuName;
        }
    }
}