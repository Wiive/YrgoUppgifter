using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [Header("Dice Settings")]
    public Shaker shakerDice1;
    public Shaker shakerDice2;

    public float diceDuration;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shakerDice1.Shake(diceDuration);
            shakerDice2.Shake(diceDuration);
        }
    }
}
