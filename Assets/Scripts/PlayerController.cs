﻿using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour,IPointerDownHandler, IDragHandler {

    [Tooltip("Smoothness in movement while dragging")]
    public float smoothness;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void SelectObject()
    {
        Debug.Log("Selecting object:" + gameObject.name);
        ShapeGlobalVars.selectedObject = this.gameObject;        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Vector2.Lerp(transform.position,Input.mousePosition,smoothness);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SelectObject();
    }
}
