using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TodoView : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputName;
    [SerializeField] private TMP_InputField inputLimit;
    [SerializeField] private TMP_InputField inputOwner;
    [SerializeField] private Button submitButton;
    [SerializeField] private TextMeshProUGUI submitButtonText;
    [SerializeField] private TextMeshProUGUI[] taskFields;
    [SerializeField] private TextMeshProUGUI[] ownerFields;
    [SerializeField] private TextMeshProUGUI[] limitFields;
    [SerializeField] private Button[] SubmitButtons;
    [SerializeField] private Button[] deleteButtons;

    private TodoModel _model;
    private TodoController _controller;

    void Awake()
    {
        _model = new TodoModel();
        _controller = new TodoController(_model);
        submitButton.onClick.AddListener(() => {
        _controller.ExecuteSubmit(inputName.text, inputLimit.text, inputOwner.text);
        ClearInputs();
        inputName.text = "";
        inputLimit.text = "";
        inputOwner.text = "";
        });
        _model.OnDataChanged += RenderList;
        RenderList();
    }

    private void ClearInputs()
    {
        inputName.text = "";
        inputLimit.text = "";
        inputOwner.text = "";
        if (submitButtonText != null) submitButtonText.text = "Submit";
    }
    private void RenderList()
     {
        for (int i = 0; i < taskFields.Length; i++)
        {
            if(taskFields[i] == null) continue;
            if (i < _model.TodoList.Count)
            {
                 TaskData data = _model.TodoList[i];
                 taskFields[i].text = $"[{data.Limit}] {data.Owner} : {data.Name}";
            }
            else
            {
            taskFields[i].text = "No Task";
            }
            if (i < deleteButtons.Length)
            {
                int index = i;
                deleteButtons[i].onClick.RemoveAllListeners();
                deleteButtons[i].onClick.AddListener(() => _controller.ExecuteDelete(index));
                deleteButtons[i].gameObject.SetActive(i < _model.TodoList.Count);
            }
        }
    }
}

