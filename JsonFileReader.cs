using UnityEngine;
using System.Collections;

public class JsonFileReader {

	public static string LoadJsonAsResource(string path){
		string jsonFilePath = path.Replace(".json", "");
		TextAsset loadedJsonfile = Resources.Load<TextAsset>(jsonFilePath);
		return loadedJsonfile.text;
	}

}
