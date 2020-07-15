using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class S_SoundEffects : MonoBehaviour
{
    [SerializeField]
    Sonic sonic;

    AudioSource source;

    bool hasPlayed = false;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
