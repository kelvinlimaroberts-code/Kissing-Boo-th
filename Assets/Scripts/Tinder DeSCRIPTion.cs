using UnityEngine;
using TMPro;
using System;
using UnityEngine.InputSystem;

public class TinderDeSCRIPTion : MonoBehaviour
{
    public TMP_Text textDisplay;
    public GameObject ImageDisplayer;
    private SpriteRenderer _spriteDisplayer;
    [Header("monster info")]
    public int monsterIndex { get; private set; } = 0;
    public int totalMonsters = 6;
    public string[] monsterName;
    public int[] monsterAge;
    public string[] monsterDescription;
    public Sprite[] monsterPFP;
    public bool swiping = true;

    [Header("camera")]
    private Vector2 mousePosition = new Vector2(0, 0);
    public Camera mainCam;
    public Transform startTransform;
    public Transform dateTransform;
    public event Action StartDate;

    [Header("buttons")]
    [SerializeField] private GameObject redButton;
    [SerializeField] private GameObject greenButton;


    void Awake()
    {
        _spriteDisplayer = ImageDisplayer.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        displayInformation();
        changeCamTransform(startTransform);
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
        swiping = false;
        toggleButtonDisplay();
        changeCamTransform(dateTransform);
        StartDate?.Invoke();
    }

    void changeCamTransform(Transform Tran)
    {
        mainCam.transform.position = Tran.position;
        mainCam.transform.rotation = Tran.rotation;
    }

    void toggleButtonDisplay()
    {
        redButton.SetActive(swiping);
        greenButton.SetActive(swiping);
    }
}
