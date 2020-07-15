using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(AudioSource))]
public class L_Displayer : MonoBehaviour
{
    [SerializeField]
    Sonic sonic;

    [SerializeField]
    Sprite[] numbers;

    Image image;

    AudioSource source;

    void Awake()
    {
        image = GetComponent<Image>();
        source = GetComponent<AudioSource>();

        UpdateDisplay();
    }

    void OnGUI()
    {
        if (sonic.LifeUp)
        {
            UpdateDisplay();
            source.clip = sonic.GetLifeEffect;
            source.Play();
            sonic.LifeUp = false;
        }
    }

    void UpdateDisplay()
    {
        if (sonic.Lives > 9)
        {
            image.sprite = numbers[9];
        }
        else
        {
            image.sprite = numbers[sonic.Lives];
        }
    }
}
