using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [TextArea] public string text;
    public AudioClip voiceLine;
    public Sprite currentEmotion;
    public PlayerResponse[] responses;
    public bool isTell;
}
