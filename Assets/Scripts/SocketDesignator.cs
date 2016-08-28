using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the Socket by designating it with an appropriate shape 
/// Also handles its highlight effect
/// </summary>
public class SocketDesignator : MonoBehaviour {

    public ShapeGlobalVars.ShapeStyle socketType;
    public bool isComplete;

    private Image _imageComponent;
    private Color startColor;

    void Start()
    {
        _imageComponent = GetComponent<Image>();
        startColor = _imageComponent.color;
    }

    /// <summary>
    /// Tuens on the Highlight Effect when correct shape is inside
    /// </summary>
    public void HighlightOn()
    {
        _imageComponent.color = Color.green;
    }

    /// <summary>
    /// Turns off the highlight Effect
    /// </summary>
    public void HighlightOff()
    {
        _imageComponent.color = startColor;
    }
}
