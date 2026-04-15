using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TodoView : MonoBehaviour
{
    [SerializeField] private TMP_InputField inName, inLimit, inOwner;
    [SerializeField] private Button submitBtn;
    [SerializeField] private TextMeshProUGUI submitTxt;
    [SerializeField] private TextMeshProUGUI[] labels; 
    [SerializeField] private Button[] editBtns, delBtns;

    private TodoModel _model;
    private TodoController _ctlr;

    void Awake()
    {
        _model = new TodoModel();
        _ctlr = new TodoController(_model);

        _model.OnChanged += Refresh;
        if (submitBtn != null) submitBtn.onClick.AddListener(OnSubmit);

        Refresh();
        Debug.Log("TodoView initialized.");
    }

    void OnSubmit()
    {
        var data = new TaskData { Name = inName.text, Limit = inLimit.text, Owner = inOwner.text };
        _ctlr.ExecuteSave(data);

        inName.text = inLimit.text = inOwner.text = "";
        if (submitTxt != null) submitTxt.text = "Submit";
    }

    void Refresh()
    {
        for (int i = 0; i < labels.Length; i++)
        {
            if (labels[i] == null) continue;

            bool hasData = i < _model.List.Count;
             int idx = i;

             labels[i].text = hasData ? _model.List[i].GetText() : "-";

            if (i < delBtns.Length && delBtns[i] != null) 
            {
                delBtns[i].onClick.RemoveAllListeners();
                if (hasData) delBtns[i].onClick.AddListener(() => _ctlr.ExecuteDelete(idx));
                delBtns[i].gameObject.SetActive(hasData);
            }

            if (i < editBtns.Length && editBtns[i] != null) 
            {
                editBtns[i].onClick.RemoveAllListeners();
                if (hasData) editBtns[i].onClick.AddListener(() => SetEditMode(idx));
                editBtns[i].gameObject.SetActive(hasData);
            }
        }
    }

    void SetEditMode(int idx)
    {
        var d = _model.List[idx];
        inName.text = d.Name; inLimit.text = d.Limit; inOwner.text = d.Owner;
     if (submitTxt != null) submitTxt.text = "Update";
      _ctlr.StartEdit(idx);
    }
}
