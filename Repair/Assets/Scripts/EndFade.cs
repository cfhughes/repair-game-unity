using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndFade : MonoBehaviour
{
    // Should refer external object, eventually
    public Image background;
    public GameObject caution;
    public TMP_Text score;

    //string testString = "This is a test.";

    // Start is called before the first frame update
    void Start()
    {
        //image = GetComponent<Image>();
        //score = GetComponent<TMP_Text>();
        background.color = new Color(background.color.r, background.color.g, background.color.b, 0);
        caution.SetActive(false);
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

    public void enableCaution(bool a)
    {
        caution.SetActive(a);
    }

    public void Fade(bool fadeIn)
    {
        if(fadeIn)
        {
            StartCoroutine(FadeTo(1.0f, 5.0f));
        }
        else
        {
            print("fade out");
            background.color = new Color(background.color.r, background.color.g, background.color.b, 0);
        }
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float startTime = Time.time;
        float endTime = startTime + aTime;
        while(Time.time < endTime)
        {
            float fadePercent = (Time.time - startTime) / aTime;
            background.color = new Color(background.color.r, background.color.g, background.color.b, fadePercent);
            yield return null;
        }
    }
}
