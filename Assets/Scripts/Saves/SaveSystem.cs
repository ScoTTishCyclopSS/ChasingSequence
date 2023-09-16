using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class SaveSystem
{
	public static SaveData data;

    public static void SaveData()
	{
		var formatter = new BinaryFormatter();

		var path = Application.persistentDataPath + "/1.sav";
		var stream = new FileStream(path, FileMode.Create);
		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static void LoadData()
	{
		var path = Application.persistentDataPath + "/1.sav";
		if (File.Exists(path))
		{
			try
			{
				var formatter = new BinaryFormatter();
				var stream = new FileStream(path, FileMode.Open);

				data = formatter.Deserialize(stream) as SaveData;
				stream.Close();

				if (data == null)
				{
					Debug.LogError("Save file corrupted. Created new one.");
					data = new SaveData();
				}
			} catch
			{
				Debug.LogError("Save file corrupted. Created new one.");
				data = new SaveData();
			}
			
		} else
		{
			Debug.Log("Save file not found in " + path + "  Created new one.");
			data = new SaveData();
		}
	}
}
