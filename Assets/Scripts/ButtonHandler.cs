using UnityEngine;
using System.Collections;

/// <summary>
/// Script that can act as one stop destination for handling different types of button clicks in UI
/// </summary>
public class ButtonHandler : MonoBehaviour {

    #region Singleton
    static ButtonHandler bhInstance = null;
    public static ButtonHandler Instance
    {
        get
        {
            if (bhInstance != null)
            {
                return bhInstance;
            }
            else {
                Debug.Log("Creating Button Handler Instance...");
                bhInstance = GameObject.Find("Canvas").GetComponent<ButtonHandler>();
                return bhInstance;
            }
        }
    }
    #endregion

    #region MonoBehaviour   

    public GameObject shapePrefab;

    public void HandleButtonClick(ShapeGlobalVars.ButtonTypes btnType)
    {
        switch (btnType)
        {
            case ShapeGlobalVars.ButtonTypes.CreateCircle:
            case ShapeGlobalVars.ButtonTypes.CreateSquare:
            case ShapeGlobalVars.ButtonTypes.CreateTriangle:
                GameObject toCreate = GameObject.Instantiate(shapePrefab) as GameObject;
                toCreate.GetComponent<PlayerController>().SelectObject();

                if(btnType==ShapeGlobalVars.ButtonTypes.CreateCircle)
                    toCreate.GetComponent<ShapeShifter>().ShiftShape(ShapeGlobalVars.ShapeStyle.Circle);

                if (btnType == ShapeGlobalVars.ButtonTypes.CreateSquare)
                    toCreate.GetComponent<ShapeShifter>().ShiftShape(ShapeGlobalVars.ShapeStyle.Square);

                if (btnType == ShapeGlobalVars.ButtonTypes.CreateTriangle)
                    toCreate.GetComponent<ShapeShifter>().ShiftShape(ShapeGlobalVars.ShapeStyle.Triangle);

                toCreate.transform.SetParent(this.transform, false);
                toCreate.transform.localScale = ShapeGlobalVars.defaultShapeScale;
                               
                toCreate.transform.localPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);      
                                                 
                break;

            case ShapeGlobalVars.ButtonTypes.ShiftShape:
                if (ShapeGlobalVars.selectedObject != null)
                {
                    ShapeShifter _target = ShapeGlobalVars.selectedObject.GetComponent<ShapeShifter>();
                    //Specific shifting
                    //_target.ShiftShape(ShapeGlobalVars.ShapeStyle.Square);

                    //Cyclic Shifting
                    if((int)_target.currentShape.shapeName!=2)
                        _target.ShiftShape(_target.currentShape.shapeName+1);
                    else
                        _target.ShiftShape(0);
                }
                break;

            case ShapeGlobalVars.ButtonTypes.ShowHint:
                AdsManager.instance.ShowRewardedAd(ShapeGlobalVars.RewardTypes.Hint);
                break;
            default:
                break;
        }
    }

    #endregion
}
