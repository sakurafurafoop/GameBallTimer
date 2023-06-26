using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public enum AudioName { Button, Clear, Miss, OK, Result};
    [SerializeField] private AudioClip audioButton;
    [SerializeField] private AudioClip audioClear;
    [SerializeField] private AudioClip audioMiss;
    [SerializeField] private AudioClip audioOK;
    [SerializeField] private AudioClip audioResult;
    private Dictionary<AudioName, AudioClip> audioDic;
    private AudioSource source;

    public void InitGame()
    {
        source = this.gameObject.GetComponent<AudioSource>();
        audioDic = new Dictionary<AudioName, AudioClip>
        {
            { AudioName.Button, audioButton },
            { AudioName.Clear, audioClear },
            { AudioName.Miss, audioMiss },
            { AudioName.OK, audioOK },
            { AudioName.Result, audioResult }
        };
    }

    public void PlaySE(AudioName name)
    {
        source.PlayOneShot(audioDic[name]);
    }

}
