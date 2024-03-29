﻿using UnityEngine;
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
        CreateCircle,
        CreateSquare,
        CreateTriangle,
        ShiftShape,
        ShowHint
    }

    public enum RewardTypes
    {
        None,
        Hint,
        Creation,
        ShapeShift
    }

    public static Vector3 defaultShapeScale = new Vector3(2f, 2f, 1f);

    public static GameObject selectedObject;
}
