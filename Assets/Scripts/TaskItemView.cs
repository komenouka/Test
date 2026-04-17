using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskItemView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI taskName;
    [SerializeField] private Button editButton, deleteButton;

    public void Setup(int index, TaskData data, System.Action<int> onEdit, System.Action<int> onDelete)
    {
        if (taskName != null) taskName.text = data.ToString();
        
        editButton.onClick.RemoveAllListeners();
        editButton.onClick.AddListener(() => onEdit(index));
        
        deleteButton.onClick.RemoveAllListeners();
        deleteButton.onClick.AddListener(() => onDelete(index));
    }
}