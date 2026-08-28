using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VoteScreen : MonoBehaviour
{
    [SerializeField] private Button[] voteButtons;
    [SerializeField] private TMP_Text[] voteLabels;
    [SerializeField] private ResultScreen resultScreen;

    private List<MonsterData> candidates;
    private MonsterData imposter;

    public void Show(List<MonsterData> candidates, MonsterData imposter)
    {
        this.candidates = candidates;
        this.imposter = imposter;
        gameObject.SetActive(true);

        for (int i = 0; i < voteButtons.Length; i++)
        {
            bool hasCandidate = i < candidates.Count;
            voteButtons[i].gameObject.SetActive(hasCandidate);
            if (hasCandidate)
            {
                voteLabels[i].text = candidates[i].monsterName;
                int captured = i;
                voteButtons[i].onClick.RemoveAllListeners();
                voteButtons[i].onClick.AddListener(() => Vote(captured));
            }
        }
    }

    private void Vote(int index)
    {
        MonsterData accused = candidates[index];
        bool correct = accused == imposter;
        gameObject.SetActive(false);
        resultScreen.Show(correct, imposter);
    }
}