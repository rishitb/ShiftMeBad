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

    [Tooltip("Extent of scalabillity of this shape")]
    [Range(0,10)]
    public int scalability;

    [Tooltip("Resistance of this shape to Fire")]
    [Range(0, 1)]
    public float fireResistance;

    [Tooltip("Resistance of this shape to water/ice")]
    [Range(0, 1)]
    public float waterResistance;
}
