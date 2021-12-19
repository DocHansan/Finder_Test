using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnimator : MonoBehaviour
{
    [Range(0f, 5f)]
    public float FadeTime;

    Graphic _fadingObject;

    void Awake()
    {
        _fadingObject = GetComponent<Graphic>();
    }

    public void FadeIn()
    {
        StartCoroutine(MakeFade());
    }

    IEnumerator MakeFade()
    {
        _fadingObject.color = ChangeAlpha(_fadingObject.color, 0);
        while (_fadingObject.color.a < 1.0f)
        {
            _fadingObject.color = AddAlpha(_fadingObject.color, Time.deltaTime / FadeTime);
            yield return null;
        }

    }

    Color AddAlpha(Color changingColor, float alphaOffset)
    {
        return new Color(changingColor.r, changingColor.g, changingColor.b, changingColor.a + alphaOffset);
    }

    Color ChangeAlpha(Color changingColor, float newAlpha)
    {
        return new Color(changingColor.r, changingColor.g, changingColor.b, newAlpha);
    }
}

