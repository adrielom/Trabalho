using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    public TextAsset text;
    string allText;
    List<string> eachline;

    void Start () {

        eachline = new List<string> ();

        allText = text.text;

        eachline.AddRange (allText.Split ("\n"[0]));

        gameObject.GetComponent<Text>().text = string.Format( eachline.ToString());
      
	}
	

}
