using UnityEngine;

public class MonsterVisualDisplay : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private MonsterData currentData;

    public void SetMonster(MonsterData data)
    {
        currentData = data;
        spriteRenderer.sprite = data.normalVisual;
    }

    public void SetVisual(int index)
    {
        bool valid = index >= 0 && currentData.reactionVisuals != null && index < currentData.reactionVisuals.Length;
        spriteRenderer.sprite = valid ? currentData.reactionVisuals[index] : currentData.normalVisual;
    }
}