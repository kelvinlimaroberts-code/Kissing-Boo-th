using UnityEngine;
using TMPro;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField] private Transform anchor;
    [SerializeField] private Camera cam;
    [SerializeField] private TMP_Text bubbleText;

    private void LateUpdate()
    {
        transform.position = anchor.position;
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }

    public void Show(string text)
    {
        bubbleText.text = text;
        gameObject.SetActive(true);
    }
}

