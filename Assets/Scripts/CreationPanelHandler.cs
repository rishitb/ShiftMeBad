using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Collections;

public class CreationPanelHandler : MonoBehaviour, IPointerDownHandler
{
    [Tooltip("Time taken for buttons to popup and wait")]
    public float effectDelay;

    private List<GameObject> buttonObjects;
    private bool effectOn;
    private bool drawerOpen;

    void Start()
    {
        effectOn = false;
        drawerOpen = false;
        buttonObjects = new List<GameObject>();
        foreach (RectTransform child in this.transform)
        {
            if (child.GetComponent<ButtonDesignator>())
                buttonObjects.Add(child.gameObject);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!drawerOpen)
        {
            drawerOpen = true;
            StartCoroutine(ShowButtons());
        }
        else
        {
            drawerOpen = false;
            StartCoroutine(HideButtons());
        }
    }

    IEnumerator ShowButtons()
    {
        if (!effectOn)
        {
            effectOn = true;
            for (int i = 0; i < buttonObjects.Count; i++)
            {
                buttonObjects[i].transform.DOScale(Vector3.one, effectDelay);
                yield return new WaitForSeconds(effectDelay);
            }
            effectOn = false;
        }
    }

    IEnumerator HideButtons()
    {
        if (!effectOn)
        {
            effectOn = true;
            for (int i = buttonObjects.Count - 1; i >= 0; i--)
            {
                buttonObjects[i].transform.DOScale(Vector3.zero, effectDelay);
                yield return new WaitForSeconds(effectDelay);
            }
            effectOn = false;
        }
    }
}
