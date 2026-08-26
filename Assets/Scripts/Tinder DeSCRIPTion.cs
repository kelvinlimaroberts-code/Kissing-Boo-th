using UnityEngine;
using UnityEngine.UI;

public class TinderDeSCRIPTion : MonoBehaviour
{
    public Text textDisplay;
    public string[] monsterName;
    public int[] monsterAge;
    public string[] monsterDescription;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textDisplay.text = ("Name: " + name[0]);
    }


}
