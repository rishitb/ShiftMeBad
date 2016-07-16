using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Reflection;

public class ShapeShifter : MonoBehaviour {

    [HideInInspector]
    public ShapesHolder _ShapesHolder;

    [HideInInspector]
    public bool isShifting;

    public Shape currentShape;

    private CanvasGroup canvasGroupComponent;
    private Image imageComponent;

    void Awake()
    {
        _ShapesHolder = GameObject.Find("ShapesRefHolder").GetComponent<ShapesHolder>();    //Not assigning through inspector as might cause issues for instantiation mechanic
        canvasGroupComponent = GetComponent<CanvasGroup>();
        imageComponent = GetComponent<Image>();
    }

    void Start()
    {
        UpdateShape(currentShape.shapeName);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.D) && ShapeGlobalVars.selectedObject==this.gameObject)
            Debug.Log("Name: " + currentShape.shapeName + " " + currentShape.fireResistance + " " + currentShape.waterResistance);

        if (Input.GetKeyDown(KeyCode.Alpha1) && !isShifting)
            ShiftShape(ShapeGlobalVars.ShapeStyle.Circle);

        if (Input.GetKeyDown(KeyCode.Alpha2) && !isShifting)
            ShiftShape(ShapeGlobalVars.ShapeStyle.Square);

        if (Input.GetKeyDown(KeyCode.Alpha3) && !isShifting)
            ShiftShape(ShapeGlobalVars.ShapeStyle.Triangle);
    }


    /// <summary>
    /// Shifts the shape of the current object to the desired shape if it is currently not the same
    /// </summary>
    /// <param name="destinationShape">shape to transform into, sprite number array (to be replaced)</param>
    public void ShiftShape(ShapeGlobalVars.ShapeStyle destinationShape) //This parameter will be replaced by the shape enum of desired shape
    {
        if (ShapeGlobalVars.selectedObject!=null && ShapeGlobalVars.selectedObject == this.gameObject)
        {
            if (currentShape.shapeName != destinationShape)
            {
                if (!isShifting)
                    StartCoroutine(ShiftShapeCR(destinationShape));
            }
        }
    }

    /// <summary>
    /// The main Co routine that handles the shifting of shapes for this object
    /// </summary>
    /// <param name="destinationShape"></param>
    /// <returns></returns>
    IEnumerator ShiftShapeCR(ShapeGlobalVars.ShapeStyle destinationShape)
    {
        isShifting = true;
        UIHelper.Instance.FadeOut(canvasGroupComponent);
        UIHelper.Instance.FillOut(imageComponent);        

        while (UIHelper.Instance.filling || UIHelper.Instance.fading)
            yield return new WaitForSeconds(0.05f);

        UpdateShape(destinationShape);
        UIHelper.Instance.FadeIn(canvasGroupComponent);
        UIHelper.Instance.FillIn(imageComponent);

        isShifting = false;
    }

    /// <summary>
    /// Updates all properties of the current shape according to the destination shape
    /// i.e Revamps the look and feel of the shape :)
    /// </summary>
    void UpdateShape(ShapeGlobalVars.ShapeStyle destinationShape)
    {
        currentShape = _ShapesHolder.shapesInGame.Single(s => s.shapeName == destinationShape);

        //Scalability and other game based properties must have been updated when shape was updated        
        //Manually assign properties that need to be reflected in components
        Destroy(GetComponent<Collider2D>());

        //Component copier module
        System.Type t = currentShape.collider.GetType();
        Component c = gameObject.AddComponent(t);
        BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
        PropertyInfo[] propInfo = t.GetProperties(flags);
        foreach (var pinfo in propInfo)
        {
            if (pinfo.CanWrite)
            {
                try
                {
                    pinfo.SetValue(c, pinfo.GetValue(currentShape.collider, null), null);
                }
                catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
            }
        }
        FieldInfo[] finfos = t.GetFields(flags);
        foreach (var finfo in finfos)
        {
            finfo.SetValue(c, finfo.GetValue(currentShape.collider));
        }

        imageComponent.sprite = currentShape.shapeImage;
        GetComponent<Rigidbody2D>().mass = currentShape.mass;

    }
}
