using UnityEngine;
using TMPro;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField] private TMP_Text bubbleText;

    public void Show(string text)
    {
        bubbleText.text = text;
        gameObject.SetActive(true);
    }
}