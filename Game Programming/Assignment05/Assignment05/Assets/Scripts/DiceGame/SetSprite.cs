using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSprite : MonoBehaviour
{
    public Image playerSprite;
    public List<Sprite> avatarSprite;

    public void UpdateSprite(int currentSprite)
    {
        playerSprite.sprite = avatarSprite[currentSprite];
    }
}
