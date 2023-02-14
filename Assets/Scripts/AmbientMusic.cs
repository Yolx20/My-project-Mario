using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientMusic : MonoBehaviour
{
    public AudioClip Ambientmusic;
    [Range(0, 5)]
    public float volumeMusic;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayAudioOnLoop(Ambientmusic, volumeMusic);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
