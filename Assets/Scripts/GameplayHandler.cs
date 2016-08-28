using UnityEngine;
using System.Collections;

public class GameplayHandler : MonoBehaviour {

    //TODO: Might have to change to OntriggerEnter depending on how physics is implemented

    private ShapeShifter _shapeShifter;
    private SocketDesignator _targetSocket;

    public bool insideSocket;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<SocketDesignator>())
        {
            SocketDesignator _temp = other.gameObject.GetComponent<SocketDesignator>();
            if ((_temp.socketType == _shapeShifter.currentShape.shapeName) && !_temp.isComplete)
            {
                _temp.HighlightOn();
                insideSocket = true;
                _targetSocket = _temp;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        insideSocket = false;
        if(_targetSocket!=null)
            _targetSocket.HighlightOff();
        _targetSocket = null;
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Heat") && !_shapeShifter.currentShape.heatResistant)
        {
            //We can add some effect when the object is destroyed
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Cold") && !_shapeShifter.currentShape.coldResistant)
        {
            //We can add some effect when the object is destroyed
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Locks the Object onto the Socket
    /// </summary>
    public void LockObject()
    {
        if (_targetSocket != null)
        {
            Debug.Log("Initiating Lock");

            this.transform.GetComponent<PlayerController>().enabled = false;
            this.GetComponent<Rigidbody2D>().gravityScale = 0;      //might not be needed
            this.transform.localPosition = _targetSocket.transform.localPosition;
            this.GetComponent<Collider2D>().enabled = false;
            //this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

            _targetSocket.isComplete = true;
        }
    }
}
