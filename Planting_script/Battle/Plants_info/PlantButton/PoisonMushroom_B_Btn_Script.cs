﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonMushroom_B_Btn_Script : MonoBehaviour {

    public string name = "PoisonMushroom_B";
    public GameObject game_obj;
    public GameObject delete_obj;
    public GameObject add_obj;
    public GameObject Select_Panel;
    public GameObject Choose_Panel;
    public GameObject PoisonMushroom_R_Btn_Choose;
    public GameObject PoisonMushroom_R_Btn_Select;

    public void GameObj_press_Choose()
    {
        add_obj.SetActive(true);
    }

    public void GameObj_press_Select()
    {
        delete_obj.SetActive(true);
    }

    public void DeleteObj_press()
    {
        DestroyObject(game_obj); //파괴하고 다시 Choose_panel에 새로 만들어줘야 한다.
        DestroyObject(delete_obj);
        DestroyObject(add_obj);
        loginScript.Instance.DeletePlantName(name);

        GameObject a = (GameObject)Instantiate(PoisonMushroom_R_Btn_Choose); //이거 지워주면 선택패널에서 고르는 패널로 다시 안돌아간다.
        a.transform.SetParent(Choose_Panel.transform, false);
    }

    public void AddObj_press()
    {
        Debug.Log("mmmmmmmmmmmmmm" + Select_Panel.transform.childCount);
        if (Select_Panel.transform.childCount <= 3)
        {
            DestroyObject(game_obj); //파괴하고 다시 Choose_panel에 새로 만들어줘야 한다.
            DestroyObject(delete_obj);
            DestroyObject(add_obj);
            loginScript.Instance.SendPlantName(name);

            //이제 여기에 4개 되면 못만들게 만들어야 한다.
            GameObject a = (GameObject)Instantiate(PoisonMushroom_R_Btn_Select);
            a.transform.SetParent(Select_Panel.transform, false);
        }
        else
        {
            Debug.Log("DELETE");
        }
    }

    void Awake()
    {
        Select_Panel = GameObject.Find("Select_Panel");
        Choose_Panel = GameObject.Find("Choose_Panel");
        PoisonMushroom_R_Btn_Choose = Resources.Load("Prefabs/PoisonMushroom_B_Btn") as GameObject;
        PoisonMushroom_R_Btn_Select = Resources.Load("Prefabs/PoisonMushroom_B_Btn_Select") as GameObject;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
