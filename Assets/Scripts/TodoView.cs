using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TodoView : MonoBehaviour
{
    [SerializeField] private TMP_InputField inName;
    [SerializeField] private Button editButton;
    [SerializeField] private TextMeshProUGUI editText;
    [SerializeField] private TextMeshProUGUI errorText;

    [SerializeField] private TextMeshProUGUI[] names;
    [SerializeField] private TMP_InputField[] rowOwnerInputs;
    [SerializeField] private TMP_InputField[] rowLimitInputs;
    [SerializeField] private Button[] EditButtons;
    [SerializeField] private Button[] deleteButtons;

    private TodoModel _model;
    private TodoController _controller;

    public void Awake()
    {
        _model = new TodoModel();
        _controller = new TodoController(_model);

        _model.OnChanged += UpdateTasks;
        _controller.OnValidationError += ShowError;

        if (editButton != null) editButton.onClick.AddListener(OnEditTasks);

        UpdateTasks();
        if (errorText != null) errorText.text = "";
    }

    public void OnEditTasks()
    {
        if (errorText != null) errorText.text = "";
        
        TaskData data = new TaskData { Name = inName.text };
        _controller.SaveTask(data);

        if (string.IsNullOrEmpty(errorText.text))
        {
            inName.text = "";
            if (editText != null) editText.text = "Edit";
        }
    }


    public void UpdateTasks()
    {
        for (int index = 0; index < names.Length; index++)
        {
            if (names[index] == null) continue;

            UpdateTaskRow(index);    
        }
    }

    public void UpdateTaskRow(int index)
    {
        bool hasData = index < _model.List.Count;

        if (hasData)
        {
            var task = _model.List[index];
            names[index].text = task.Name;

            if (string.IsNullOrEmpty(rowOwnerInputs[index].text)) rowOwnerInputs[index].text = task.Owner;
            if (string.IsNullOrEmpty(rowLimitInputs[index].text)) rowLimitInputs[index].text = task.Limit;
        }
        else
        {
            names[index].text = "";
            rowOwnerInputs[index].text = "";
            rowLimitInputs[index].text = "";
        }

        SetRowActive(index, hasData);
    }

    public void SetEditMode(int targetIndex)
    {
        TaskData taskToEdit = _model.List[targetIndex];
        inName.text = taskToEdit.Name; 

        if (editText != null) editText.text = "Update";
        _controller.StartEdit(targetIndex);
    }

    public void SetRowActive(int index, bool isActive)
    {
        rowOwnerInputs[index].gameObject.SetActive(isActive);
        rowLimitInputs[index].gameObject.SetActive(isActive);

        ConfigureButton(EditButtons[index], isActive, () => SetEditMode(index));
        ConfigureButton(deleteButtons[index], isActive, () => _controller.DeleteTask(index));
    }

    public void ConfigureButton(Button button, bool isActive, UnityEngine.Events.UnityAction action)
    {
        if (button == null) return;

        button.gameObject.SetActive(isActive);
        button.onClick.RemoveAllListeners();
        if (isActive) button.onClick.AddListener(action);
    }

    public void ShowError(string message)
    {
        if (errorText != null)
        {
            errorText.text = message;
            errorText.color = Color.red;
        }
    }
}
