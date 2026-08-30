using UnityEngine;

[CreateAssetMenu(menuName = "MonsterData")]
public class MonsterData : ScriptableObject
{
    public string monsterName;
    public Sprite normalVisual;
    public Sprite[] reactionVisuals;
    public Dialogue[] dialogue;
    public int[] dayStartLine = new int[3]; // index into dialogue[] where each day begins
    [TextArea] public string likes;
    [TextArea] public string dislikes;
    [TextArea] public string lookDescription;
}