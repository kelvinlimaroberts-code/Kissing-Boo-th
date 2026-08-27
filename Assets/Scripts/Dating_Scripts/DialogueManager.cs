using UnityEngine;
using UnityEngine.AdaptivePerformance.Provider;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [SerializeField] private SpeechBubble bubble;

    private Dialogue[] activeLines;
    private int lineIndex;

    private void Awake()
    {
        Instance = this;
    }

    public void StartDate(MonsterData monster, bool isImposter)
    {
        activeLines = isImposter ? monster.imposterDialogue : monster.normalDialogue;
        lineIndex = 0;
        ShowCurrentLine();
    }

    public void PickResponse(int responseIndex)
    {
        lineIndex = activeLines[lineIndex].responses[responseIndex].nextLine;
        ShowCurrentLine();
    }

    private void ShowCurrentLine()
    {
        bubble.Show(activeLines[lineIndex].text);
    }
}

