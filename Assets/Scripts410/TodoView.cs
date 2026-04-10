using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class TodoView : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private Button submitButton;
    [SerializeField] private InputField[] todoFields;
    [SerializeField] private Button[] deleteButtons;

    private TodoModel _model;
    private TodoController _controller;

    void Awake()
    {
        _model = new TodoModel();
        _controller = new TodoController(_model);
        submitButton.onClick.AddListener(() => {
        _controller.ExecuteSubmit(inputField.text); 
        inputField.text = "";
        });
        _model.OnDataChanged += RenderList;
        for (int i = 0; i < deleteButtons.Length; i++)
        {
            int index = i;
            deleteButtons[i].onClick.AddListener(() => {
            _controller.RemoveItem(index);
            });
        }
    }
    private void RenderList()
    {
        for (int i = 0; i < todoFields.Length; i++)
        {
            if (todoFields[i] == null) continue;
            if (i < _model.TodoList.Count)
            {
                todoFields[i].text = _model.TodoList[i];
                todoFields[i].interactable = true;
            }
            else
            {
               todoFields[i].text = ""; 
               todoFields[i].interactable = true;
            }
        }
    }
}

