using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnimator : MonoBehaviour
{
    [SerializeField][Range(0f, 5f)]
    public float FadeTime;

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

    public void FadeOut(float time, GameObject fadingObject)
    {
        StartCoroutine(Fade(time, fadingObject, false));
    }

    IEnumerator Fade(float time, Text fadingObject, bool isNeedFadeIn)
    {
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

    IEnumerator Fade(float time, GameObject fadingObject, bool isNeedFadeIn)
    {
        SpriteRenderer spriteRenderer = fadingObject.GetComponent<SpriteRenderer>();
        if (isNeedFadeIn)
        {
            while (spriteRenderer != null && spriteRenderer.color.a < 1.0f)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a + (Time.deltaTime / time));
                yield return null;
            }
        }
        else
        {
            while (spriteRenderer != null && spriteRenderer.color.a > 0.0f)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a - (Time.deltaTime / time));
                yield return null;
            }
        }
    }
}

