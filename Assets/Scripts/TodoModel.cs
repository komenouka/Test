using System;
using System.Collections.Generic;

public class TodoModel
{
    private readonly List<TaskData> _list = new();
    public IReadOnlyList<TaskData> List => _list;
    public event Action OnChanged;

    public void Save(int index, TaskData data)
    {
        if (string.IsNullOrWhiteSpace(data?.Name)) return;

        if (index >= 0 && index < _list.Count) _list[index] = data;
        else _list.Add(data);

        OnChanged?.Invoke();
    }

    public void Delete(int index)
    {
        if (index >= 0 && index < _list.Count)
        {
            _list.RemoveAt(index);
            OnChanged?.Invoke();
        }
    }
}