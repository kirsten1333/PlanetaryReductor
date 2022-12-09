using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyScript : MonoBehaviour
{
    GameObject Reductor;
    Animator[] arrOfAnims;
    bool isout = false;

    void Start()
    {
        Reductor = GameObject.Find("Planetarny_Reductor");
        arrOfAnims = Reductor.GetComponentsInChildren<Animator>();
        GetComponentInParent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if (IsInTransition()) return; 
        if (isout) FlyIn();
        else FlyOut();
    }
    
    public void FlyOut()
    {
        foreach (var item in arrOfAnims)
        {
            item.SetBool("isOut", true);
        }
        isout = true;
    }

    public void FlyIn(GameObject part)
    {
        Animator animatorOfPart;
        animatorOfPart = part.GetComponent<Animator>();
        if (isout)
        {
            animatorOfPart.SetBool("isOut", false);
        }
    }

    public void FlyIn()
    {
        foreach (var item in arrOfAnims)
        {
            item.SetBool("isOut", false);
        }
        isout = false;
    }

    public bool IsInTransition()
    {
        foreach (var item in arrOfAnims)
        {
            if (item.IsInTransition(0))
            {
                return true;
            }
        }
        return false;
    }

}
