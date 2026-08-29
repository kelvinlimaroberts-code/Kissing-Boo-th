using UnityEngine;
using TMPro;
using System.Collections;

public class NightTransition : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text nightText;
    [SerializeField] private float holdSeconds = 5f;

    public IEnumerator ShowNight(int night, int totalNights)
    {
        panel.SetActive(true);
        nightText.text = "Night " + night + " / " + totalNights;
        yield return new WaitForSeconds(holdSeconds);
        panel.SetActive(false);
    }
}