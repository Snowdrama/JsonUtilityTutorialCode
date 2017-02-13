using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemLoader : MonoBehaviour {
	public List<Item> itemsList;
	public Dictionary<int, Item> items;
	void Awake(){
		items = new Dictionary<int, Item>();
		ItemDictionary dictionary = JsonUtility.FromJson<ItemDictionary>(JsonFileReader.LoadJsonAsResource("Items/ItemDictionary.json"));
		foreach (string dictionaryItem in dictionary.items) 
		{
			LoadItem(dictionaryItem);
		}

		foreach(KeyValuePair<int, Item> entry in items)
		{
			Item temp = entry.Value;
			itemsList.Add(temp);
		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadItem(string path){
		string myLoadedItem = JsonFileReader.LoadJsonAsResource(path);
		Item myItem = JsonUtility.FromJson<Item>(myLoadedItem);


		if(items.ContainsKey(myItem.itemID)){
			Debug.LogWarning("Item " + myItem.itemName + " Key already exists as " + items[myItem.itemID].itemName);
			items[myItem.itemID] = myItem;
		} else{
			items.Add(myItem.itemID, myItem);
		}
	}
}
