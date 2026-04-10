using UnityEngine;

public class TodoController
{
    private readonly TodoModel _model;
    private int _editingIndex = -1;

    public TodoController(TodoModel model)
    {
        _model = model;
    }
    public void ExecuteSubmit(string input)
    {
        _model.AddTodo(input);
    }

    public void UpdateTodo(int index, string newText)
    {
        if (index >= 0 && index < _TodoList.Count)
        {
            _model.UpdateTodo(index, input);
        }
    }
    
    public void StartEditing(int index)
    {
        _editingIndex = index;
    }
    public void RemoveItem(int index)
    {
        _model.DeleteTodo(index);
        _editingIndex = -1;
    }
    public void ExecuteUpdate(int index, string val)
    {
        _model.UpdateTodo(index, val);
    }

    public void ExecuteDelete(int index)
    {
        _model.DeleteTodo(index);
    } 
    public bool IsEditing => _editingIndex != -1;
    public string GetCurrentText() => IsEditing ? _model.TodoList[_editingIndex] : "";
}
