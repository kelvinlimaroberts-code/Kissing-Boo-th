using UnityEngine;
using TMPro;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] private GameObject survivePanel;
    [SerializeField] private GameObject diePanel;
    [SerializeField] private TMP_Text imposterRevealText;

    public void Show(bool correct, MonsterData imposter)
    {
        gameObject.SetActive(true);
        survivePanel.SetActive(correct);
        diePanel.SetActive(!correct);
        imposterRevealText.text = "The imposter was " + imposter.monsterName;
    }
}