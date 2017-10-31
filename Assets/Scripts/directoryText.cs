using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class directoryText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		GameObject can = GameObject.Find ("FileExplorerCanvas");
		directory temp = can.GetComponent<directory>();
		Text directoryText = gameObject.GetComponent<Text> ();
		directoryText.text = temp.dir.FullName;
	}
}
