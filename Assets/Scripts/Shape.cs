using System;
using UnityEngine;

[Serializable]
public class Shape {

    [Tooltip("Name/Type of this current shape")]
    public ShapeGlobalVars.ShapeStyle shapeName;

    [Tooltip("Collider reference for the current shape")]
    public Collider2D collider;

    [Tooltip("Sprite image used to represent this shape")]
    public Sprite shapeImage;

    [Tooltip("Weight of the shape which affects physics properties")]
    public float mass;

    [Tooltip("Is the object scalable?")]
    public bool scalability;

    [Tooltip("Is the object resistant to heat?")]
    public bool heatResistant;

    [Tooltip("Is the object resistant to cold?")]
    public bool coldResistant;
}
