using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// A helper class which exposes different generic UI functions
/// Gameobject must have Canvas group and/or UI Image as components
/// </summary>
public class UIHelper : MonoBehaviour {

    #region Singleton
    static UIHelper uihInstance = null;
    public static UIHelper Instance
    {
        get
        {
            if (uihInstance != null)
            {
                return uihInstance;
            }
            else {
                Debug.Log("Creating UI Helper Instance...");
                uihInstance = GameObject.Find("Canvas").GetComponent<UIHelper>();
                return uihInstance;
            }
        }
    }
    #endregion

    #region MonoBehaviour
    [Tooltip("Speed with which the effect takes place")]
    public float effectSpeed;
    [Tooltip("Duration of wait for the effect to complete")]
    public float effectWait;

    [HideInInspector]
    public bool fading;
    [HideInInspector]
    public bool filling;
    
    /// <summary>
    /// Fades in the UI element 
    /// </summary>
    /// <param name="toFade">Canvas Group to be faded in</param>
    public void FadeIn(CanvasGroup toFade)
    {
        if(!fading)
            StartCoroutine(FadeInCR(toFade));
    }

    /// <summary>
    /// Fades out the UI element
    /// </summary>
    /// <param name="toFade">Canvas Group to be faded out</param>
    public void FadeOut(CanvasGroup toFade)
    {
        if(!fading)
            StartCoroutine(FadeOutCR(toFade));
    }

    /// <summary>
    /// Fills in the UI element
    /// </summary>
    /// <param name="toFill">Image component to be filled in</param>
    public void FillIn(Image toFill)
    {
        if(!filling)
            StartCoroutine(FillInCR(toFill));
    }

    /// <summary>
    /// Fills out (Clears) the UI element
    /// </summary>
    /// <param name="toFill">Image component to be filled out (cleared)</param>
    public void FillOut(Image toFill)
    {
        if (!filling)
            StartCoroutine(FillOutCR(toFill));
    }

    IEnumerator FadeInCR(CanvasGroup toFade)
    {
        while (toFade.alpha < 1f)
        {
            fading = true;
            toFade.alpha += effectSpeed;
            yield return new WaitForSeconds(effectWait);
        }
        fading = false; 
    }

    IEnumerator FadeOutCR(CanvasGroup toFade)
    {
        while (toFade.alpha > 0f)
        {
            fading = true;
            toFade.alpha -= effectSpeed;
            yield return new WaitForSeconds(effectWait);
        }
        fading = false;
    }

    IEnumerator FillInCR(Image toFill)
    {
        while (toFill.fillAmount < 1f)
        {
            filling = true;
            toFill.fillAmount += effectSpeed;
            yield return new WaitForSeconds(effectWait);
        }
        filling = false;
    }

    IEnumerator FillOutCR(Image toFill)
    {
        while (toFill.fillAmount > 0f)
        {
            filling = true;
            toFill.fillAmount -= effectSpeed;
            yield return new WaitForSeconds(effectWait);
        }
        filling = false;
    }

    #endregion
}
