using UnityEngine;
using System.Collections;

public class GameplayHandler : MonoBehaviour {

    //TODO: Might have to change to OntriggerEnter depending on how physics is implemented

    private ShapeShifter _shapeShifter;

    void Start()
    {
        _shapeShifter = GetComponent<ShapeShifter>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Heat") && !_shapeShifter.currentShape.heatResistant)
        {
            //We can add some effect when the object is destroyed
            Destroy(this.gameObject);
        }

        if (col.gameObject.CompareTag("Cold") && !_shapeShifter.currentShape.coldResistant)
        {
            //We can add some effect when the object is destroyed
            Destroy(this.gameObject);
        }
    }

}
