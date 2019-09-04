using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineGameScript : MonoBehaviour
{
    public GameObject ResultPopUp;
    public int step;
    public Button bu1, bu2;

	// Use this for initialization
	void Start ()
    {
        step = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void makeLine()
    {

        //bu1.GetComponent<Image>().sprite = Resources.Load
        //bu2.GetComponent<Image>().sprite = Resources.Load

    }

    public void ClickLine(Button bu)
    {
        if (Random.Range(0, 100) < 50)
        {
            Debug.Log("성공");
            step++;
            makeLine();
            
        }
        else
        {
            Debug.Log("실패");
            ResultPopUp.SetActive(true);
        }

        if (step == 4)
        {

            ResultPopUp.SetActive(true);
        }
    }

    public void OkButtonClicked()
    {
        AutoFade.LoadLevel("MainScene 3", 1, 1, Color.black);
    }
}
