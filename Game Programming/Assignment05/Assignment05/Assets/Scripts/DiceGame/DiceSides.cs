using UnityEngine;

public class DiceSides : MonoBehaviour
{
    public Sprite side1;
    public Sprite side2;
    public Sprite side3;
    public Sprite side4;
    public Sprite side5;
    public Sprite side6;

    SpriteRenderer spriteRenderer;

    private int currentValue;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void RollTheDie()
    {
        Sprite[] diceSides = new Sprite[5];
        int newSide = (int)Random.Range(1, 7);
        switch (newSide)
        {
            case 1:
                spriteRenderer.sprite = side1;
                SetValue(1);
                break;
            case 2:
                spriteRenderer.sprite = side2;
                SetValue(2);
                break;
            case 3:
                spriteRenderer.sprite = side3;
                SetValue(3);
                break;
            case 4:
                spriteRenderer.sprite = side4;
                SetValue(4);
                break;
            case 5:
                spriteRenderer.sprite = side5;
                SetValue(5);
                break;
            case 6:
                spriteRenderer.sprite = side6;
                SetValue(6);
                break;
        }
    }

    private void SetValue(int value)
    {
        currentValue = value;
    }

    public int GetValue()
    {
        return currentValue;
    }
}
