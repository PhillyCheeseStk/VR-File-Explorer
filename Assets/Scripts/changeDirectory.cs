using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;



	public class changeDirectory : MonoBehaviour {

		public static string filePath;


		public void goBack () {
			GameObject can = GameObject.Find ("FileExplorerCanvas");
			directory temp = can.GetComponent<directory>();
			if (temp.dir.Parent.ToString ().Length > 3) {
				temp.dir = temp.dir.Parent;
				temp.rm = true;
				temp.deez = true;
			}
		}

		public void OnButtonClick(Button button)
		{
			if (button.tag == "folder") {
				goToDirectory (button);
			}

			if (button.tag == "file") {
				openFile (button);
			}
				
		}

		public void goToDirectory (Button button) {
			GameObject can = GameObject.Find ("FileExplorerCanvas");
			directory temp = can.GetComponent<directory>();
			string oldPath = temp.dir.FullName;
			Text curr = button.GetComponentInChildren<Text> ();
			string newPath = oldPath + "\\" + curr.text;
			string extension = Path.GetExtension (newPath);
	
			DirectoryInfo t = new DirectoryInfo (newPath);
			temp.dir = t;
			temp.rm = true;
			temp.deez = true;

		}

		public void openFile(Button button){
			GameObject can = GameObject.Find ("FileExplorerCanvas");
			directory temp = can.GetComponent<directory>();
			string oldPath = temp.dir.FullName;
			Text curr = button.GetComponentInChildren<Text> ();
			string newPath = oldPath + "\\" + curr.text;
			string extension = Path.GetExtension (newPath);
			filePath = newPath;
		}
}
