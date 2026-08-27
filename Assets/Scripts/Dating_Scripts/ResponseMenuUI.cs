using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResponseMenuUI : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private TMP_Text[] buttonLabels;

    public void Show(Dialogue line)
    {
        gameObject.SetActive(true);
        for (int i = 0; i < buttons.Length; i++)
        {
            bool hasResponse = i < line.responses.Length;
            buttons[i].gameObject.SetActive(hasResponse);
            if (hasResponse)
            {
                buttonLabels[i].text = line.responses[i].text;
                int captured = i;
                buttons[i].onClick.RemoveAllListeners();
                buttons[i].onClick.AddListener(() => DialogueManager.Instance.PickResponse(captured));
            }
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}