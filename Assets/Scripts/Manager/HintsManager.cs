using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Xml;

/// <summary>
/// Reads the Hints XML file that has Level data and returns the appropriate hint
/// </summary>
public class HintsManager : MonoBehaviour {

    public static HintsManager instance = null;

    public Text _hintTxt;

    private TextAsset levelsTxt;
    private XmlNodeList levelsList;
    private Dictionary<string, string> hints;   

    //This will eventually come from a place like Level manager 
    public string lnum;


    void Awake()
    {
        if (HintsManager.instance == null)
        {
            HintsManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        hints = new Dictionary<string, string>();

        levelsTxt = (TextAsset)Resources.Load("Hints");
        XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
        xmlDoc.LoadXml(levelsTxt.text);
        levelsList = xmlDoc.GetElementsByTagName("Level");

        foreach (XmlNode l in levelsList)
        {
            hints.Add(l.Attributes["number"].Value, l.FirstChild.InnerText);
        }
    }

    /// <summary>
    /// Gives the Hint for the current Level
    /// </summary>
    /// <param name="levelNumber">Current level number</param>
    /// <returns></returns>
    public string GetLevelHint(string levelNumber)
    {
        if (hints.ContainsKey(levelNumber))
            return hints[levelNumber];
        else
        {
            Debug.LogError("Hints XML doesnt have any level with current level number");
            return "";
        }
    }

    /// <summary>
    /// Shows and sets the Hint text for the current Level
    /// </summary>
    public void ShowLevelHint()
    {
        _hintTxt.gameObject.SetActive(true);
        _hintTxt.text = GetLevelHint(lnum);
    }
}
