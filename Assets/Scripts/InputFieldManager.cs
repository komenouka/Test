using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{    
  [SerializeField] private Text[] texts;
  [SerializeField] private InputField inputFields;
  private int clickCount = 0;
  private int editingIndex = -1;

  public void OnClickCheck()
  {
    if(texts == null || inputFields == null) return;
    if(editingIndex != -1)
    {
        texts[editingIndex].text = inputFields.text;
        editingIndex = -1;
        inputFields.text = "";
    }

    else if(clickCount < texts.Length)
    {
        texts[clickCount].text = inputFields.text;
        clickCount++;
        inputFields.text = "";
    }
  }

  public void SelectTask(int index)
  {
    if (index < clickCount)
    {
      inputFields.text = texts[index].text;
      editingIndex = index;
      inputFields.ActivateInputField();
    }
  }
}