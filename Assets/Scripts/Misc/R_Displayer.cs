using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class R_Displayer : MonoBehaviour
{
    [SerializeField]
    Sprite[] numbers;

    [SerializeField]
    Sonic sonic;

    [SerializeField]
    Image[] images;

    private void Start()
    {
        StartCoroutine("UpdateRingDisplay");
    }

    private void OnGUI()
    {
        if (sonic.UpdateRing)
        {
            sonic.UpdateRing = false;
            StartCoroutine("UpdateRingDisplay");
        }
    }

    IEnumerator UpdateRingDisplay()
    {
        string rings = sonic.Rings.ToString();
        for(int i = 0; i < rings.Length; i++)
        {
            images[i].sprite = numbers[(int)char.GetNumericValue(rings[(rings.Length - 1) - i])];
        }
        yield return null;
    }
}
