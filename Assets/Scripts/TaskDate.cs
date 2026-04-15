using System;

[Serializable]
public class TaskData 
{
    public string Name, Limit, Owner;
    public string GetText() => $" {Name}";
}