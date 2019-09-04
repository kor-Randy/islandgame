﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class MyCharacter
{
    public int Name;
    public int Hungry;
    public int Thirsty;
    public int Ill;
    public string Condition;

    public MyCharacter(int name,int hungry,int thirsty,int ill,string condition)
    {
        Name = name;
        Hungry = hungry;
        Thirsty = thirsty;
        Ill = ill;
        Condition = condition;
    }

}


public class MyCharacterData : SingleTon<MyCharacterData>
{

    public List<int> CharacterName = new List<int>();
    //다른 스크립트에서 캐릭터 3개를 뽑으면 그의 Name번호를 저장해놓는다.
    public int NowCharacterName=0;
    public List<MyCharacter> ThreeCharacter = new List<MyCharacter>();
    MyCharacter mch;

    public bool[] isWorked; //하루에 일을 했는지 안했는지 설정


    

    void Start()
    {
        //if(!PlayerPrefs.HasKey("Start"))
            Load();
        //MaterialData.Instance.MaterialList[0].Count += 100;

    }

    public void Save()
    {
        StartCoroutine(MyCharacterSave());
    }
    public void Load()
    {
        StartCoroutine(MyCharacterLoad());
    }
    public void Clear()
    {
        StartCoroutine(MyCharacterClear());
    }



    IEnumerator MyCharacterSave()
    {
        List<MyCharacter> TempCharacter = new List<MyCharacter>();
        
        for (int i = 0; i < ThreeCharacter.Count; i++)
        {

            mch = new MyCharacter(
                ThreeCharacter[i].Name,
                ThreeCharacter[i].Hungry,
                ThreeCharacter[i].Thirsty,
                ThreeCharacter[i].Ill,
                ThreeCharacter[i].Condition
                );

            TempCharacter.Add(mch);
        }








        JsonData CharacterJson = JsonMapper.ToJson(TempCharacter);

        if (EndingEvent.Instance.path == Application.persistentDataPath)
            File.WriteAllText(Application.persistentDataPath + "/MyCharacterData.json", CharacterJson.ToString());
        else
            File.WriteAllText(EndingEvent.Instance.path + "/Resources/MyCharacterData.json", CharacterJson.ToString());

        yield return null;

    }
    IEnumerator MyCharacterClear()
    {
        List<MyCharacter> TempCharacter = new List<MyCharacter>();

        for (int i = 0; i < 3; i++)
        {

            mch = new MyCharacter(
                i,
                50,
                50,
                0,
                "normal"
                );

            TempCharacter.Add(mch);
        }








        JsonData CharacterJson = JsonMapper.ToJson(TempCharacter);

        if (EndingEvent.Instance.path == Application.persistentDataPath)
            File.WriteAllText(Application.persistentDataPath + "/MyCharacterData.json", CharacterJson.ToString());
        else
            File.WriteAllText(EndingEvent.Instance.path + "/Resources/MyCharacterData.json", CharacterJson.ToString());

        yield return null;

    }
    // Update is called once per frame

    IEnumerator MyCharacterLoad()
    {

        //string FoodString = File.ReadAllText(Application.persistentDataPath + "/FoodData.json");
        string MyCharacterString;
        if (EndingEvent.Instance.path == Application.persistentDataPath)
            MyCharacterString = File.ReadAllText(Application.persistentDataPath + "/MyCharacterData.json");
        else
            MyCharacterString = File.ReadAllText(EndingEvent.Instance.path + "/Resources/MyCharacterData.json");


        Debug.Log(MyCharacterString); // 첫 줄 출력

        JsonData itemData = JsonMapper.ToObject(MyCharacterString);
        //태그로 정렬 가능?

        ParsingMyCharacter(itemData);

        yield return null;

    }

    private void ParsingMyCharacter(JsonData Data)
    {

        MyCharacter mc;
        for (int i = 0; i < 3; i++)
        {


            //text = Data[i]["Text"].ToString();
            //Debug.Log(Data[i]["Text"]);

            //name = Data[i]["Name"].ToString();
            //Debug.Log(Data[i]["Name"]);
            //count = int.Parse(Data[i]["Count"].ToString());

            mc = new MyCharacter(
               int.Parse(Data[i]["Name"].ToString()),
                int.Parse(Data[i]["Hungry"].ToString()),
                int.Parse(Data[i]["Thirsty"].ToString()), 
                int.Parse(Data[i]["Ill"].ToString()), 
                Data[i]["Condition"].ToString());
            

            ThreeCharacter.Add(mc);

            

        }
        for (int i=0; i < ThreeCharacter.Count; i++)
        {
            CharacterName.Add(ThreeCharacter[i].Name);
        }

    }
}
