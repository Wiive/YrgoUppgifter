using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [Header("Dice Settings")]
    public Shaker shakerDice1;
    public Shaker shakerDice2;
    public float diceDuration;
    public AudioClip rollDiceSound;

    [Header("Score Effect")]
    public AudioClip scoreSound;
    public float scoreSoundDelay = 0.5f;

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


    public void ScoreEffect(ParticleSystem particelEffect)
    {        
        particelEffect.Play();
        StartCoroutine(PlaySoundWithDelay(scoreSound, scoreSoundDelay));
    }

    private IEnumerator PlaySoundWithDelay(AudioClip sound, float delay)
    {
        if (audioSource == null)
            yield break;
        yield return new WaitForSeconds(delay);
        audioSource.PlayOneShot(sound);
    }
}
