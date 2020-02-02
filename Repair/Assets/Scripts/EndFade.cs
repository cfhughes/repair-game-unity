using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndFade : MonoBehaviour
{
    // Should refer external object, eventually
    public Image image;
    public TMP_Text score;

    //string testString = "This is a test.";

    // Start is called before the first frame update
    void Start()
    {
        //image = GetComponent<Image>();
        //score = GetComponent<TMP_Text>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        score.enabled = false;
        //Fade(); // Here for testing.
    }

    public void setText(string a)
    {
        score.text = a;
    }

    public void enableText(bool a)
    {
        score.enabled = a;
    }

    public void Fade()
    {
        StartCoroutine(FadeTo(1.0f, 5.0f));
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float startTime = Time.time;
        float endTime = startTime + aTime;
        while(Time.time < endTime)
        {
            float fadePercent = (Time.time - startTime) / aTime;
            image.color = new Color(image.color.r, image.color.g, image.color.b, fadePercent);
            yield return null;
        }
    }
}
