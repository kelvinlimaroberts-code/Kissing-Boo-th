using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TinderDeSCRIPTion : MonoBehaviour
{
    [Header("game objects")]
    public TMP_Text textDisplay;
    public GameObject ImageDisplayer;
    private SpriteRenderer _spriteDisplayer;
    public SoundManager soundManager;

    [Header("monster info")]
    public List<MonsterData> roster;
    private int monsterIndex = 0;

    [Header("selection")]
    public GameSettings settings;
    private List<MonsterData> selected = new List<MonsterData>();

    [Header("buttons")]
    [SerializeField] private GameObject redButton;
    [SerializeField] private GameObject greenButton;

    [Header("hookup")]
    public RoundManager roundManager;

    public bool swiping = true;

    void Awake()
    {
        _spriteDisplayer = ImageDisplayer.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        displayInformation();
    }

    void displayInformation()
    {
        MonsterData m = roster[monsterIndex];
        _spriteDisplayer.sprite = m.normalVisual;
        textDisplay.text = "Name: " + m.monsterName + "\nDesc: " + m.lookDescription;
    }

    public void redButtonPressed()
    {
        monsterIndex++;
        if (monsterIndex >= roster.Count)
        {
            monsterIndex = 0;
        }
        displayInformation();
    }

    public void greenButtonPressed()
    {
        MonsterData current = roster[monsterIndex];

        if (selected.Contains(current))
        {
            selected.Remove(current);
        }
        else if (selected.Count < settings.monstersPerRun)
        {
            selected.Add(current);
        }

        if (selected.Count >= settings.monstersPerRun)
        {
            startDate();
        }
        else
        {
            redButtonPressed();
        }
    }

    public void startDate()
    {
        swiping = false;
        toggleButtonDisplay();
        soundManager.PlayMusic(0);
        roundManager.StartRound(selected);
    }

    void toggleButtonDisplay()
    {
        redButton.SetActive(swiping);
        greenButton.SetActive(swiping);
    }

    public void StartSwiping()
    {
        soundManager.StopMusic();
        swiping = true;
        toggleButtonDisplay();
    }
}