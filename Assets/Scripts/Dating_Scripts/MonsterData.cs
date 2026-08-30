using UnityEngine;

[CreateAssetMenu(menuName = "MonsterData")]
public class MonsterData : ScriptableObject
{
    public string monsterName;
    public Sprite normalVisual;
    public Sprite imposterVisual;
    public Sprite currentEmotion;
    public Dialogue[] dialogue;
    public int[] dayStartLine = new int[3];
    [TextArea] public string likes;
    [TextArea] public string dislikes;
    [TextArea] public string lookDescription;
}