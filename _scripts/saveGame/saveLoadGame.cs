/*
 ************************************************
 * Name: saveLoadGame.cs
 * Updated: 11/12/2017
 * Author: Sean Francis
 * Description: Script Holding Functions to
                Save and Load Game Data.
 ************************************************
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class saveLoadGame : MonoBehaviour{

	public static List<saveData> savedGames = new List<saveData>();
    public static int saveSlot = 0;
    public static int maxSlots = 3; /*NOT USED YET*/
    
    void Awake(){
        
       // Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
        
    }
    
    public static void create(){
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveSlot" + saveSlot.ToString() + ".gd");
        bf.Serialize(file, savedGames[saveSlot]);
        file.Close();
        
    }
    
    public static void overwrite(){
        
        if(File.Exists(Application.persistentDataPath + "/saveSlot" + saveSlot.ToString() + ".gd")){
            
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveSlot" + saveSlot.ToString() + ".gd", FileMode.Open);
            bf.Serialize(file, savedGames[saveSlot]);
            file.Close();
        
        } else {
            
            create();
            
        }
        
    }
    
    public static void load(){
        
        if(File.Exists(Application.persistentDataPath + "/saveSlot" + saveSlot.ToString() + ".gd")){
            
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveSlot" + saveSlot.ToString() + ".gd", FileMode.Open);

            savedGames[saveSlot] = (saveData)bf.Deserialize(file);
            
            file.Close();
            
        }
        
    }
    
    public static void loadAll(){
        
        for(int i = 0; i < maxSlots; i++){
            
            saveSlot = i;
            
            load();
            
        }
        
    }
    
    public static void delete(){
        
        if(File.Exists(Application.persistentDataPath + "/saveSlot" + saveSlot.ToString() + ".gd")){
            
            BinaryFormatter bf = new BinaryFormatter();
            File.Delete(Application.persistentDataPath + "/saveSlot" + saveSlot.ToString() + ".gd");
            
        }
        
    }
    
}
