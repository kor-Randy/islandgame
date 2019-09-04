using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Clear()
    {
        EndingEvent.Instance.Clear();
        FoodData.Instance.Clear();
        ManufactureData.Instance.clear();
        MyCharacterData.Instance.Clear();
        Work.Instance.Clear();
        PlayerPrefs.DeleteAll();
    }
}
