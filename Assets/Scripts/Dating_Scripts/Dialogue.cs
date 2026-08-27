using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [TextArea] public string text;
    public PlayerResponse[] responses;
    public bool isTell;
}
