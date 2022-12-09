using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    GameObject[] arrOfButtons;
    bool IsActive = false;
    FlyScript flyScript;
    void Start()
    {
        flyScript = GameObject.Find("Button").GetComponent<FlyScript>();
        GetComponentInParent<Button>().onClick.AddListener(OnClick);
        arrOfButtons = GetArrOfChilds();
    }
    private void OnClick()
    {
        if (flyScript.IsInTransition()) return;
        if (IsActive) 
        {   ButtonController.UnHideAll();
            HideAll(); 
        }
        else UnHideAll();
    }

    private void HideAll()
    {
        foreach (var item in arrOfButtons)
        {
            item.SetActive(false);
        }
        IsActive = false;
    }
    private void UnHideAll()
    {
        foreach (var item in arrOfButtons)
        {
            item.SetActive(true);
        }
        IsActive = true;
    }

    private GameObject[] GetArrOfChilds()
    {
        List<GameObject> listOfChilds = new();
        var parentT = gameObject.transform.parent;
        var childs = parentT.childCount;
        for (int i = 0; i < childs; i++)
        {
            if (gameObject == parentT.GetChild(i).gameObject) continue;
            listOfChilds.Add(parentT.GetChild(i).gameObject);
        }
        return listOfChilds.ToArray();
    }
}
