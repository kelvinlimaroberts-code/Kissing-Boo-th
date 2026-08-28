using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileCardUI : MonoBehaviour
{
    [SerializeField] private Image photo;
    [SerializeField] private Image phone_image;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text likesText;
    [SerializeField] private TMP_Text dislikesText;

    public void Show(MonsterData data)
    {
        photo.sprite = data.normalVisual;
        nameText.text = data.monsterName;
        likesText.text = data.likes;
        dislikesText.text = data.dislikes;
    }
}

