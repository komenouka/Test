using System;
using UnityEngine;
using System.Collections.Generic;

public class TodoModel
{
    private List<string> _todoList = new List<string>();
    public IReadOnlyList<string> TodoList => _todoList;
    public event Action OnDataChanged;
    public void AddTodo(string name)
    {
        if (string.IsNullOrEmpty(name)) return;
        _todoList.Add(name); 
        OnDataChanged?.Invoke(); 
    }
    public void UpdateTodo(int index, string newText)
    {
        if (index >= 0 && index < _todoList.Count)
        {
            _todoList[index] = newText;
            OnDataChanged?.Invoke();
        }
    }
    public void DeleteTodo(int index)
    {
        if (index < 0 || index >= _todoList.Count) return;
        _todoList.RemoveAt(index);
        OnDataChanged?.Invoke();
    }

    public void RemoveTodo(int index)
    {
        if (index >= 0 && index < _todoList.Count)
        {
            _todoList.RemoveAt(index);
            OnDataChanged?.Invoke(); 
        }
    }
}