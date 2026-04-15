public class TodoController
{
    private readonly TodoModel _model;
    public int EditIndex { get; private set; } = -1;

    public TodoController(TodoModel model) => _model = model;

    public void StartEdit(int index) => EditIndex = index;

    public void ExecuteSave(TaskData data)
    {
        _model.Save(EditIndex, data);
        EditIndex = -1;
    }

    public void ExecuteDelete(int index)
    {
        _model.Delete(index);
        if (EditIndex == index) EditIndex = -1;
    }
}