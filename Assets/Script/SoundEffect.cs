using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource aus;
    public AudioClip CollectingSound;
    public AudioClip CollectingGemSound;
    public AudioClip CollectingBad;
    public AudioClip AddTime;
    public AudioClip RemoveTime;
    public void CollectingHeartSound()
    {
        if (CollectingSound)
        {
            aus.PlayOneShot(CollectingSound);
        }
    }
    public void CollectingGem()
    {
        if (CollectingGemSound)
        {
            aus.PlayOneShot(CollectingGemSound);
        }
    }
    public void CollectingBadItems()
    {
        if (CollectingBad)
        {
            aus.PlayOneShot(CollectingBad);
        }
    }
    public void IncreasementTIme()
    {
        if (AddTime)
        {
            aus.PlayOneShot(AddTime);
        }
    }
    public void DecreasementTime()
    {
        if (RemoveTime)
        {
            aus.PlayOneShot(RemoveTime);
        }
    }
}
