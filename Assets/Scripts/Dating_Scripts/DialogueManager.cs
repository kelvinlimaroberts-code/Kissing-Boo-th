using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [SerializeField] private SpeechBubble bubble;
    [SerializeField] private ResponseMenuUI responseMenu;
    [SerializeField] private MonsterVisualDisplay monsterVisual;

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
        Dialogue line = activeLines[lineIndex];
        bubble.Show(line.text);
        monsterVisual.SetTell(line.isTell);

        if (line.responses != null && line.responses.Length > 0)
        {
            responseMenu.Show(line);
        }
        else
        {
            responseMenu.Hide();
        }
    }
}