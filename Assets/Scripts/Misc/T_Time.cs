using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class T_Time : MonoBehaviour
{
    [SerializeField]
    Sprite[] digits;

    [SerializeField]
    Image[] images;

    void OnGUI()
    {
        float time = Time.time;
        int mins = (int)(time / 60);
        if (mins > 9)
        {
            mins = 9;
        }
        images[2].sprite = digits[mins];
        string seconds = ((int)(time % 60)).ToString();
        if (seconds.Length < 2)
        {
            images[0].sprite = digits[(int)char.GetNumericValue(seconds[0])];
            images[1].sprite = digits[0];
        }
        else
        {
            images[0].sprite = digits[(int)char.GetNumericValue(seconds[1])];
            images[1].sprite = digits[(int)char.GetNumericValue(seconds[0])];
        }
    }
}
