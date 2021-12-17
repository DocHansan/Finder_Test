using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnimator : MonoBehaviour
{
    Color _AlphaZero;
    Color _AlphaFull;

    public void FadeIn(float time, Text fadingObject)
    {
        StartCoroutine(Fade(time, fadingObject, true));
    }

    public void FadeOut(float time, Text fadingObject)
    {
        StartCoroutine(Fade(time, fadingObject, false));
    }

    IEnumerator Fade(float time, Text fadingObject, bool isNeedFadeIn)
    {
        _AlphaZero = new Color(fadingObject.color.r, fadingObject.color.g, fadingObject.color.b, 0);
        _AlphaFull = new Color(fadingObject.color.r, fadingObject.color.g, fadingObject.color.b, 1);
        if (isNeedFadeIn)
        {
            while (fadingObject.color.a < 1.0f)
            {
                fadingObject.color = new Color(fadingObject.color.r, fadingObject.color.g, fadingObject.color.b, fadingObject.color.a + (Time.deltaTime / time));
                yield return null;
            }
        }
        else
        {
            while (fadingObject.color.a > 0.0f)
            {
                fadingObject.color = new Color(fadingObject.color.r, fadingObject.color.g, fadingObject.color.b, fadingObject.color.a - (Time.deltaTime / time));
                yield return null;
            }
        }

    }
}

