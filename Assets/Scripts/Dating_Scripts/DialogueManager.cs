using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [SerializeField] private SpeechBubble bubble;
    [SerializeField] private ResponseMenuUI responseMenu;
    [SerializeField] private MonsterVisualDisplay monsterVisual;

    private Dialogue[] activeLines;
    private int lineIndex;
    private bool isImposter;

    private void Awake()
    {
        Instance = this;
    }

    public void StartDate(MonsterData monster, bool imposter)
    {
        activeLines = monster.dialogue;
        isImposter = imposter;
        lineIndex = 0;
        ShowCurrentLine();
    }

    public void PickResponse(int responseIndex)
    {
        PlayerResponse response = activeLines[lineIndex].responses[responseIndex];

        if (response.requiresCharge && !ChargeManager.Instance.TrySpendCharge())
        {
            return;
        }

        lineIndex = (isImposter && response.imposterNextLine >= 0)
            ? response.imposterNextLine
            : response.nextLine;

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