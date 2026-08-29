using UnityEngine;
using TMPro;
using System;
using UnityEngine.InputSystem;

public class TinderDeSCRIPTion : MonoBehaviour
{
    [Header("game objects")]
    public TMP_Text textDisplay;
    public GameObject ImageDisplayer;
    private SpriteRenderer _spriteDisplayer;
    public SoundManager soundManager;

    [Header("monster info")]
    public int monsterIndex { get; private set; } = 0;
    public int totalMonsters = 6;
    public string[] monsterName;
    public int[] monsterAge;
    public string[] monsterDescription;
    public PickButton[] monsterSelectButton;
    public Sprite[] monsterPFP;
    public bool swiping = true;


    [Header("buttons")]
    [SerializeField] private GameObject redButton;
    [SerializeField] private GameObject greenButton;
    private int[] selectedMstrID = new int[3];
    private int ChoiceCounter = 0;



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
        _spriteDisplayer.sprite = monsterPFP[monsterIndex];
        textDisplay.text = ("Name: " + monsterName[monsterIndex] + "\n" + "Age: " + monsterAge[monsterIndex] + "\n" + "Desc: " + monsterDescription[monsterIndex]);
    }

    public void redButtonPressed()
    {
        monsterIndex++;
        if (monsterIndex >= totalMonsters)
        {
            monsterIndex = 0;
            displayInformation();
        }
        else
        {
            displayInformation();
        }
    }

    public void greenButtonPressed()
    {
        if (ChoiceCounter < 3)  //only do if 3 choices havnt been made already
        {
            selectedMstrID[ChoiceCounter] = monsterIndex;
            ChoiceCounter++;
            monsterSelectButton[monsterIndex].Pick();
            redButtonPressed(); //just used to skip to next monster
        }
        else
        {
            startDate();
        }
    }

    public void startDate()
    {
        swiping = false;
        toggleButtonDisplay();
        soundManager.PlayMusic(0);
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
