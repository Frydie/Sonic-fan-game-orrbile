using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class S_LifeUp : MonoBehaviour
{
    AudioSource source;

    [SerializeField]
    Sonic sonic;

    void Start()
    {
        sonic.LifeUp = false;
    }
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (sonic.LifeUp)
        {
        }
    }
}
