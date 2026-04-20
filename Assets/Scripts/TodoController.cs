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

        _model.SaveTask(EditIndex, newTaskData);

        EditIndex = -1;
    }

    public void DeleteTask(int index)
    {
        _model.DeleteTask(index);
        if (EditIndex == index) EditIndex = -1;
    }
}