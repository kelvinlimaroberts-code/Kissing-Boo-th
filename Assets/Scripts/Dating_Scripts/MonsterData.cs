using UnityEngine;

[CreateAssetMenu(menuName = "MonsterData")]
public class MonsterData : ScriptableObject
{
    public string monsterName;
    public Sprite normalVisual;
    public Sprite imposterVisual;
    public Dialogue[] normalDialogue;
    public Dialogue[] imposterDialogue;
    [TextArea] public string likes;
    [TextArea] public string dislikes;
    [TextArea] public string lookDescription;
}