﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MainButtonManager : MonoBehaviour
{
    public Button[] peopleicon;
    public Button[] people;
    public Button[] icon;

    public GameObject manufactPopup;
    public GameObject invenPopup;
    public GameObject[] statPopup;
    public GameObject workPopup;
    public GameObject tradePopup;
    public GameObject nightPopup;
    public TextMeshProUGUI[] WorkNameText;

    string[] Work = { "옷만들기", "배만들기", "요리하기", "낚시하기", "농사짓기", "집짓기", "통신장치제작", "제약하기", "수렵하기", "탐험하기" };
    //string menuanimator;
    void Start()
    {

        // menuanimator = gameObject.GetComponent<MenuAnimator>().state;
    }

   
    public void PeopleClick(Button button)
    {


        switch (button.ToString())//각각 사람의 이미지는 MyCharacterData의 CharacterName에 있는 순서대로 해야함! 
        {

            case ("People1 (UnityEngine.UI.Button)"):
                {

                    MyCharacterData.Instance.NowCharacterName = MyCharacterData.Instance.ThreeCharacter[0].Name ;
                    for (int i = 0; i < WorkNameText.Length; i++)
                    {

                        WorkNameText[i].text = Work[i];

                    }
                    break;
                }
            case ("People2 (UnityEngine.UI.Button)"):
                {
                    MyCharacterData.Instance.NowCharacterName = MyCharacterData.Instance.ThreeCharacter[1].Name ;
                    for (int i = 0; i < WorkNameText.Length; i++)
                    {

                        WorkNameText[i].text = Work[i];

                    }
                    break;
                }
            case ("People3 (UnityEngine.UI.Button)"):
                {
                    MyCharacterData.Instance.NowCharacterName = MyCharacterData.Instance.ThreeCharacter[2].Name ;
                    for (int i = 0; i < WorkNameText.Length; i++)
                    {

                        WorkNameText[i].text = Work[i];

                    }
                    break;
                }
        }
        //Debug.Log("캐릭터 번호" + MyCharacterData.Instance.NowCharacterName);
       
        workPopup.SetActive(true);



    }
    public void IconClick(Button button)
    {
        switch (button.ToString())
        {
            case ("MissionButton (UnityEngine.UI.Button)"):

                break;
            case ("TradeButton (UnityEngine.UI.Button)"):
                tradePopup.SetActive(true);
                break;
            case ("MenuButton (UnityEngine.UI.Button)"):

                if (MenuAnimator.Instance.state != "triggerOn")
                {
                    MenuAnimator.Instance.state = "triggerOn";
                }
                else if (MenuAnimator.Instance.state == "triggerOn")
                {
                    MenuAnimator.Instance.state = "triggerOff";
                }

                MenuAnimator.Instance.TriggerCheck();


                break;
            case ("InvenButton (UnityEngine.UI.Button)"):
                invenPopup.SetActive(true);
                break;
            case ("ItemButton (UnityEngine.UI.Button)"):
                manufactPopup.SetActive(true);
                break;

            case ("NightButton (UnityEngine.UI.Button)"):
                nightPopup.SetActive(true);
                break;
        }
    }

}
