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
                PlayerResponse r = line.responses[i];
                buttonLabels[i].text = r.text;
                bool locked = r.requiresCharge && !ChargeManager.Instance.HasCharge;
                buttons[i].interactable = !locked;
                int captured = i;
                buttons[i].onClick.RemoveAllListeners();
                buttons[i].onClick.AddListener(() => DialogueManager.Instance.PickResponse(captured));
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) TryPress(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) TryPress(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) TryPress(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) TryPress(3);
    }

    private void TryPress(int index)
    {
        if (index < buttons.Length && buttons[index].gameObject.activeSelf)
        {
            buttons[index].onClick.Invoke();
        }
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}