using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TaskItemView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI taskLabel;
    [SerializeField] private Button editBtn, delBtn;

    public void Setup(int idx, TaskData data, System.Action<int> onEdit, System.Action<int> onDelete)
    {
        if (taskLabel != null) taskLabel.text = data.GetText();
        
        editBtn.onClick.RemoveAllListeners();
        editBtn.onClick.AddListener(() => onEdit(idx));
        
        delBtn.onClick.RemoveAllListeners();
        delBtn.onClick.AddListener(() => onDelete(idx));
    }
}