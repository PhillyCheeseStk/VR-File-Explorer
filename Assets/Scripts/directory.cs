using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using System.IO;
using UnityEngine.UI;

public class directory : MonoBehaviour {

	
	//used to prevent excess gameobject instantiation calls
	public bool deez;
	public bool rm; 
	public DirectoryInfo dir;
	public GameObject real;

	void Start(){
		deez = true;
		rm = false;
		dir = new DirectoryInfo (Directory.GetCurrentDirectory());
	}

	void Update () {
		
		if (deez) {

			if (rm) {
				GameObject[] filez = GameObject.FindGameObjectsWithTag ("file");
				foreach (GameObject f in filez) {
					Destroy (f);
				}
				GameObject[] folderz = GameObject.FindGameObjectsWithTag ("folder");
				foreach (GameObject f in folderz) {
					Destroy (f);
				}
				rm = false;
			}
				
			DirectoryInfo[] dirInfo = dir.GetDirectories ();
			FileInfo[] fileInfo = dir.GetFiles ();

			if (dirInfo.Length != 0) {
				//GameObject real = (GameObject) Resources.Load("Button");
				for (int i = 0; i < dirInfo.Length; i++) {
					GameObject child = Instantiate (real, real.transform.position, real.transform.rotation, GameObject.Find ("Content").transform);
					child.transform.rotation = new Quaternion (0, 0, 0, 0);
					child.tag = "folder";
					child.GetComponentInChildren<Text> ().text = dirInfo [i].Name;
				}
			}
			if (fileInfo.Length != 0) {
				//GameObject real = (GameObject) Resources.Load("Button");
				for (int i = 0; i < fileInfo.Length; i++) {
					GameObject child = Instantiate (real, real.transform.position, real.transform.rotation, GameObject.Find ("Content").transform);
					child.transform.rotation = new Quaternion (0, 0, 0, 0);
					child.tag = "file";
					child.GetComponentInChildren<Text> ().text = fileInfo [i].Name;
				}
			}

			deez = false;
		}
	}
}
