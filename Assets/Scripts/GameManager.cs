using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class GameManager : MonoBehaviour
{
    public bool[] locked = new[] { true, false, true, false, false, true, true, false };
    public GameObject[] cardsShop; 
    public bool haveUnreal = false;

    public bool inLobby;

    public bool needLoad;
    void Start()
    {
        if (YandexGame.SDKEnabled && needLoad)
        {
            MyLoad();

        }
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < locked.Length; i++)
        //{
        //    if (locked[i] && !inLobby)
        //    {
        //        // cardsShop[i].GetComponentInChildren<Image>().color = Color.white;
        //        cardsShop[i].GetComponent<Button>().interactable = true;

        //    }
        //    else if (!locked[i] && !inLobby)
        //    {
        //        // cardsShop[i].GetComponentInChildren<Image>().color = Color.black;
        //        cardsShop[i].GetComponent<Button>().interactable = false;

        //    }

        //    //if (!CheckLocked() && inLobby)
        //    //{
        //    //    GameObject.Find("OpenAllCards").GetComponent<Button>().interactable = true;
        //    //}
        //    //else if(inLobby && CheckLocked())
        //    //{
        //    //    GameObject.Find("OpenAllCards").GetComponent<Button>().interactable = false;
        //    //}

        //    //if (!haveUnreal && inLobby)
        //    //{
        //    //    GameObject.Find("Add").GetComponent<Button>().interactable = true;
        //    //}
        //    //else if (haveUnreal && inLobby)
        //    //{
        //    //    GameObject.Find("Add").GetComponent<Button>().interactable = false;
        //    //}
        //}
        
        
    }

    private bool CheckLocked()
    {
        foreach (var locker in locked)
        {
            if (!locker) return false;
        }

        return true;
    }

    public void SetSuper()
    {
        haveUnreal = true;
        MySaxve();
    }

    public void MySaxve()
    {
        YandexGame.savesData.haveSuper = haveUnreal;
        //YandexGame.savesData.lockest = locked;
        YandexGame.SaveProgress();
    }

    public void MyLoad()
    {
        haveUnreal = YandexGame.savesData.haveSuper;
        //locked= YandexGame.savesData.lockest ;
    }


    
    
}
