using UnityEngine;
using System.Collections;
/// <summary>
/// Pinch to scale scripts handles the scalability of the gameobject this is attached to.
/// </summary>
public class PinchToScale : MonoBehaviour {

	void Update(){

		if (Input.touchCount == 2) {
			
			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			//testing purposes
			Vector3 newScale = transform.localScale;
			newScale.x  = Mathf.Clamp(newScale.x - deltaMagnitudeDiff, 2, 7);//min and max scale size
			newScale.y  = Mathf.Clamp(newScale.y - deltaMagnitudeDiff, 2, 7);
			newScale.z  = Mathf.Clamp(newScale.z - deltaMagnitudeDiff, 2, 7);
			transform.localScale = newScale;
		}

	}
}
