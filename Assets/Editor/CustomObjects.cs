using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class CustomObjects : MonoBehaviour {

    [MenuItem("GameObject/Custom/BoxRegion", false, 1)]
    static void CreateBoxRegion(MenuCommand cmd)
    {
        GameObject g = new GameObject("Custom Game Object");
        Undo.RegisterCreatedObjectUndo(g, "Create " + g.name);
        Selection.activeObject = g;

        g.transform.SetParent(GameObject.Find("Canvas").transform, false);
        g.name = "Region_Box";

        //Adding required components
        g.AddComponent<RectTransform>();
        g.AddComponent<CanvasRenderer>();
        g.AddComponent<Image>();
        g.AddComponent<BoxCollider2D>();
        g.AddComponent<RegionHandler>();
        g.AddComponent<Rigidbody2D>();

        //Setting component properties
        g.GetComponent<RectTransform>().anchoredPosition.Set(0.5f, 0.5f);
        g.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        g.GetComponent<Image>().raycastTarget = false;
        g.GetComponent<Collider2D>().isTrigger = true;
        g.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;

    }

    [MenuItem("GameObject/Custom/PolyRegion", false, 2)]
    static void CreatePolyRegion(MenuCommand cmd)
    {
        GameObject g = new GameObject("Custom Game Object");
        Undo.RegisterCreatedObjectUndo(g, "Create " + g.name);
        Selection.activeObject = g;

        g.transform.SetParent(GameObject.Find("Canvas").transform, false);
        g.name = "Region_Poly";

        //Adding required components
        g.AddComponent<RectTransform>();
        g.AddComponent<CanvasRenderer>();
        g.AddComponent<Image>();
        g.AddComponent<PolygonCollider2D>();
        g.AddComponent<RegionHandler>();
        g.AddComponent<Rigidbody2D>();

        //Setting component properties
        g.GetComponent<RectTransform>().anchoredPosition.Set(0.5f, 0.5f);
        g.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        g.GetComponent<Image>().raycastTarget = false;
        g.GetComponent<Collider2D>().isTrigger = true;
        g.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;

    }
}
