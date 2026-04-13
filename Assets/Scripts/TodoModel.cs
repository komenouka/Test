using System;
using System.Collections.Generic;

[Serializable]public class TaskData 
{
    public string Name;
    public string Limit;
    public string Owner;
}

public class TodoModel
{
    private List<TaskData> _todoList = new List<TaskData>();
    public IReadOnlyList<TaskData> TodoList => _todoList;
    public event Action OnDataChanged;
    public void AddTask(string name, string Limit, string owner)    
    {
        if (string.IsNullOrEmpty(name)) return;
        _todoList.Add(new TaskData { Name = name, Limit = Limit, Owner = owner });
        OnDataChanged?.Invoke();
    }
    public void UpdateTodo(int index, string name, string Limit, string owner)    
    {
        if (index >= 0 && index < _todoList.Count)
        {
            _todoList[index].Name = name;
            _todoList[index].Limit = Limit;
            _todoList[index].Owner = owner;
            OnDataChanged?.Invoke();
        }
    }

    public void DeleteTodo(int index)
    {
        if (index >= 0 && index < _todoList.Count)
        {
            _todoList.RemoveAt(index);
            OnDataChanged?.Invoke();
        }
    }
}