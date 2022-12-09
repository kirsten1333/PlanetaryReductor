using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonController : MonoBehaviour
{
    public GameObject Part;

    FlyScript flyScript;
    GameObject Reductor;
    static List<Transform> reductorParts;
    void Start()
    {
        flyScript = GameObject.Find("Button").GetComponent<FlyScript>();
        Reductor = GameObject.Find("Planetarny_Reductor");
        reductorParts = GetChilds(Reductor.transform);
        Button.ButtonClickedEvent buttonComp = this.GetComponentInParent<Button>().onClick;
        buttonComp.AddListener(OnClick);
    }
    public void OnClick()
    {
        if (flyScript.IsInTransition()) return;
        if (Part.activeInHierarchy == false)
        {
            flyScript.FlyOut();
            HideAllExc();
            flyScript.FlyIn(Part);
            return;
        }
        foreach (var part in reductorParts)
        {
            if (part.gameObject == Part) { continue; }
            else if (part.gameObject.activeInHierarchy == true)
            {
                flyScript.FlyOut();
                HideAllExc();
                flyScript.FlyIn(Part);
                return;
            }
            else 
            {
                UnHideAll();
                flyScript.FlyOut();
                return;
            }
        }
    }

    public void HideAllExc()
    {
        UnHideAll();
        foreach (var part in reductorParts)
        {
            if (part == Part.transform) continue;
            part.gameObject.SetActive(false);
        }
    }

    public static void UnHideAll()
    {
        foreach (var part in reductorParts)
        {
            part.gameObject.SetActive(true);
        }
    }

    public static List<Transform> GetChilds(Transform parent)
    {
        List<Transform> ret = new();
        foreach (Transform child in parent) ret.Add(child);
        return ret;
    }
}
