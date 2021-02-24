using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [Header("Dice Settings")]
    public Shaker shakerDice1;
    public Shaker shakerDice2;
    public AudioClip rollDiceSound;

    public float diceDuration;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void RollDiceEffect()
    {
        shakerDice1.Shake(diceDuration);
        shakerDice2.Shake(diceDuration);
        audioSource.PlayOneShot(rollDiceSound);
    }


}
