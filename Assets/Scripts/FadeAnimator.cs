using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnimator : MonoBehaviour
{
    [SerializeField][Range(0f, 5f)]
    public float FadeTime;

    public void Fade(float time, Graphic fadingObject, bool isNeedFadeIn)
    {
        StartCoroutine(MakeFade(time, fadingObject, isNeedFadeIn));
    }

    IEnumerator MakeFade(float time, Graphic fadingObject, bool isNeedFadeIn)
    {
        fadingObject.color = ChangeAlpha(fadingObject.color, isNeedFadeIn ? 0 : 1);

        if (isNeedFadeIn)
        {
            while (fadingObject.color.a < 1.0f)
            {
                fadingObject.color = AddAlpha(fadingObject.color, time);
                yield return null;
            }
        }

        else
        {
            while (fadingObject.color.a > 0.0f)
            {
                fadingObject.color = AddAlpha(fadingObject.color, -time);
                yield return null;
            }
        }
    }

    Color AddAlpha(Color changingColor, float time)
    {
        return new Color(changingColor.r, changingColor.g, changingColor.b, changingColor.a + (Time.deltaTime / time));
    }

    Color ChangeAlpha(Color changingColor, float newAlpha)
    {
        return new Color(changingColor.r, changingColor.g, changingColor.b, newAlpha);
    }
}

