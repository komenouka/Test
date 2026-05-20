using System;

public class TodoController
{
    private readonly TodoModel _model;
    public int EditIndex { get; private set; } = -1;
    public event Action<string> OnValidationError;

    public TodoController(TodoModel model) => _model = model;

    public void StartEdit(int index) => EditIndex = index;

    public void SaveTask(TaskData newTaskData)
    {
        if (string.IsNullOrWhiteSpace(newTaskData.Name))
        {
            OnValidationError?.Invoke("Error: No TaskName!");
            return;
        }

        if (EditIndex >= 0 && EditIndex < _model.List.Count)
        {
            TaskData existingTaskData = _model.List[EditIndex];
            existingTaskData.Name = newTaskData.Name;
            _model.SaveTask(EditIndex, existingTaskData);
        }
        else
        {
            _model.SaveTask(-1, newTaskData);
        }

        EditIndex = -1;
    }

    public void DeleteTask(int index)
    {
        _model.DeleteTask(index);
        if (EditIndex == index) EditIndex = -1;
    }
}