using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour,IPointerDownHandler, IDragHandler,IPointerUpHandler {

    [Tooltip("Smoothness in movement while dragging")]
    public float smoothness;

    public Rigidbody2D grabbedObject;
    Vector2 originalPos=Vector2.zero;

    private GameplayHandler _gameplayHandler;

    void Start()
    {
        _gameplayHandler = GetComponent<GameplayHandler>();
    }

    void FixedUpdate()
    {
        if (grabbedObject!=null)
        {
          
            Vector3 MouseWorldPos3D =  Input.mousePosition;
            Vector2 MouseScreenPos2D = new Vector2(MouseWorldPos3D.x, MouseWorldPos3D.y);

            Vector2 objScreenPostion = Camera.main.WorldToScreenPoint(grabbedObject.position);

            Vector2 dir = MouseScreenPos2D - objScreenPostion;

            dir *= smoothness;

            grabbedObject.velocity = dir;
            
        }
    }

    public void SelectObject()
    {
        Debug.Log("Selecting object:" + gameObject.name);
        ShapeGlobalVars.selectedObject = this.gameObject;        
    }
    

    public void OnDrag(PointerEventData eventData)
    {
   		
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SelectObject();
        grabbedObject = ShapeGlobalVars.selectedObject.GetComponent<Rigidbody2D>();

        if (gameObject.GetComponent<ShapeShifter>().currentShape.shapeName == ShapeGlobalVars.ShapeStyle.Circle)
            gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;

		if (gameObject.GetComponent<ShapeShifter> ().currentShape.shapeName == ShapeGlobalVars.ShapeStyle.Triangle) 
		{
			gameObject.AddComponent<PinchToScale> ();
		}
        originalPos=grabbedObject.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        grabbedObject.velocity = Vector2.zero;
        grabbedObject = null;

        if (_gameplayHandler.insideSocket)
            _gameplayHandler.LockObject();
    }

   
}
