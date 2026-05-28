using System;

[Serializable]
public class TaskData
{
    public string Name { get; set; }
    public string Limit { get; set; }
    public string Owner { get; set; }

    public override string ToString() => Name;
}