using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public abstract class PersistentScore : ScriptableObject
{
    public void Save(string filename = null) 
    {
        var bf = new BinaryFormatter();
        var file = File.Create(GetPath(filename)) ;
        var json = JsonUtility.ToJson(this);

        bf.Serialize(file, json);
        file.Close();
    }


    public virtual void Load(string filename = null) 
    {
        if (File.Exists(GetPath(filename)))
        {
            var bf = new BinaryFormatter();
            var file = File.Open(GetPath(filename), FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), this);
            file.Close();
        }
    }

    public string GetPath(string ArchiveName = null) 
    {
        var ArchivefullName =string.IsNullOrEmpty(ArchiveName) ? name : ArchiveName;
        return string.Format("{0}/{1}.Ricosuave", Application.persistentDataPath,ArchivefullName);
    } 
    
}
