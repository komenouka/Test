using UnityEngine;

public class TodoController
{
    private readonly TodoModel _model;
    private int _editingIndex = -1;

    public TodoController(TodoModel model)
    {
        _model = model;
    }
    public bool IsEditing => _editingIndex != -1;
    public void ExecuteSubmit(string name, string limit, string owner)    
    {
        if (string.IsNullOrWhiteSpace(name)) return;
        if (IsEditing)
        {
            _model.UpdateTodo(_editingIndex, name, limit, owner);
            _editingIndex = -1;
        }
        else
        {
            _model.AddTask(name, limit, owner);
        }
    }
    public void ExecuteUpdate(int index, string name, string limit, string owner)
    {
        if(_editingIndex >= 0)
        {
            _model.UpdateTodo(_editingIndex, name, limit, owner);
            _editingIndex = -1;
        }
    }
    public void ExecuteDelete(int index)
    {
        _model.DeleteTodo(index);
        if (_editingIndex == index) _editingIndex = -1;
    }

 public TaskData GetEditingData()
    {
        if (IsEditing && _editingIndex < _model.TodoList.Count)
        return _model.TodoList[_editingIndex];
        return null;
    }
}
