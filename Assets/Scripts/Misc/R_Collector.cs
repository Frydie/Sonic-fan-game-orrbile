using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider))]
public class R_Collector : MonoBehaviour
{
    [SerializeField]
    Sonic sonic;

    [SerializeField]
    AudioClip clip;

    AudioSource source;

    Animator animator;

    bool collected = false;

    void Start()
    {
        gameObject.SetActive(true);
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public void DestroyRing()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!collected && other.gameObject.CompareTag("Player"))
        {
            collected = true;
            source.clip = clip;
            source.Play();
            sonic.Rings++;
            animator.Play("R_Collected");
        }
    }
}
