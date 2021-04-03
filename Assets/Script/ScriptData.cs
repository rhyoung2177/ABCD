using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class SaveScript
{
    
    public int ID;
    public string Name;
    public string Script;

    public SaveScript(int id, string name, string script)
    {
        ID = id;
        Name = name;
        Script = script;
    }
}


public class ScriptData : MonoBehaviour
{
    int i = 0;
    public List<SaveScript> ScriptList = new List<SaveScript>();

    // Start is called before the first frame update
    void Start()
    {
        ScriptList.Add(new SaveScript(0, "주인", "안녕하세요"));
        ScriptList.Add(new SaveScript(1, "Big", "안녕하세요"));
        ScriptList.Add(new SaveScript(0, "주인", "Big is my cat"));
        ScriptList.Add(new SaveScript(1, "Big", "I have to diet"));
        ScriptList.Add(new SaveScript(0, "주인", "안녕히가세요"));
        ScriptList.Add(new SaveScript(1, "Big", "가야돼"));
        ScriptList.Add(new SaveScript(0, "주인", "하기싫다"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        JsonData scriptData = JsonMapper.ToJson(ScriptList);

        File.WriteAllText(Application.dataPath + "/Script/ScriptData.json", scriptData.ToString()); 
    }

    public void Load()
    {
        string ScriptJson = File.ReadAllText(Application.dataPath + "/Script/ScriptData.json");
        JsonData scriptdata = JsonMapper.ToObject(ScriptJson);
        i++;
        Debug.Log(scriptdata[i]["ID"].ToString());
        Debug.Log(scriptdata[i]["Name"].ToString());
        Debug.Log(scriptdata[i]["Script"].ToString());
    }

    public void iplus()
    {
    }
}
