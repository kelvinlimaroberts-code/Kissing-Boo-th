using UnityEngine;

[System.Serializable]
public class PlayerResponse
{
    public string text;
    public string tone;
    public int nextLine;
    public int imposterNextLine = -1; // -1 = same as nextLine, only set this when the imposter path actually changes
    public bool requiresCharge;
}