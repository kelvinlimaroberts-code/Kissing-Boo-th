using UnityEngine;
using TMPro;
using System;
using UnityEngine.InputSystem;

public class TinderDeSCRIPTion : MonoBehaviour
{
    public TMP_Text textDisplay;
    [Header("monster info")]
    public int monsterIndex { get; private set; } = 0;
    public int totalMonsters = 6;
    public string[] monsterName;
    public int[] monsterAge;
    public string[] monsterDescription;
    public bool swiping = true;

    [Header("other")]
    public Camera mainCam;
    public Transform startTransform;
    public Transform dateTransform;
    public event Action StartDate;




    void Start()
    {
        displayInformation();
        changeCamTransform(startTransform);
    }

    void Update()
    {
        if(swiping)
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray pointerRay = mainCam.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(pointerRay, out hit))
            {
                if(hit.transform.name == "Red Button")
                {
                    redButtonPressed();
                }
                else if (hit.transform.name == "Green Button")
                {
                    greenButtonPressed();
                }
            }

        }
    }

    void displayInformation()
    {
        textDisplay.text = ("Name: " + monsterName[monsterIndex] + "\n" + "Age: " + monsterAge[monsterIndex] + "\n" + "Desc: " + monsterDescription[monsterIndex]);
    }

    void redButtonPressed()
    {
        Debug.Log("red pressed");
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

    void greenButtonPressed()
    {
        swiping = false;
        changeCamTransform(dateTransform);
        StartDate?.Invoke();
    }

    void changeCamTransform(Transform Tran)
    {
        mainCam.transform.position = Tran.position;
        mainCam.transform.rotation = Tran.rotation;
    }
}
