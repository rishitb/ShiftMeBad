using UnityEngine;
using System.Collections;

public class ShapeGlobalVars {

    public enum ShapeStyle
    {
        Circle,
        Square,
        Triangle
    };

    public enum ButtonTypes
    {
        CreateShape,// Can turn into individual types for like CreateCircle/Triangle..
        ShiftShape
    }

    public static Vector3 defaultShapeScale = new Vector3(2f, 2f, 1f);

    public static GameObject selectedObject;
}
