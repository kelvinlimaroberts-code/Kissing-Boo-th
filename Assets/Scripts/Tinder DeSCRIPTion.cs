using UnityEngine;
using TMPro;

public class TinderDeSCRIPTion : MonoBehaviour
{
    public TMP_Text textDisplay;
    public string[] monsterName;
    public int[] monsterAge;
    public string[] monsterDescription;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textDisplay.text = ("Name: " + monsterName[0]);
    }


}
