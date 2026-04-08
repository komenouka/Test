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

  public void DeleteTask(int index)
  {
    if (index < 0 || index >= clickCount) return;
    for (int i = index; i < clickCount - 1; i++)
    {
      texts[i].text = texts[i + 1].text;
    }
    
    texts[clickCount - 1].text = "";
    clickCount--;
    editingIndex = -1;
  }
}