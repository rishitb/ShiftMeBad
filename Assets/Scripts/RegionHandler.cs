using UnityEngine;
using UnityEditor;
using System.Collections;

/// <summary>
/// Handles the region activation and deactivation
/// Also exposes methods to create regions
/// </summary>
public class RegionHandler : MonoBehaviour {

    public bool isActive;

    void OnTriggerStay2D(Collider2D other)
    {
        if (!this.isActive)
        {
            if (other.gameObject.CompareTag("Player"))
                this.isActive = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            this.isActive = false;
    }
}
