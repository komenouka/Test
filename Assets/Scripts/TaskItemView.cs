using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskItemView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI taskNameText;
    [SerializeField] private TMP_InputField ownerInput;
    [SerializeField] private TMP_InputField limitInput;
    [SerializeField] private Button editButton;
    [SerializeField] private Button deleteButton;

    public void Setup(TaskData data, System.Action onEdit, System.Action onDelete)
    {
        taskNameText.text = data.Name;
        ownerInput.text = data.Owner;
        limitInput.text = data.Limit;
        
        editButton.onClick.RemoveAllListeners();
        editButton.onClick.AddListener(() => onEdit?.Invoke());
        
        deleteButton.onClick.RemoveAllListeners();
        deleteButton.onClick.AddListener(() => onDelete?.Invoke());
    }
}