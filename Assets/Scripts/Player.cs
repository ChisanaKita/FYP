using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using VRF.BaseClass;

namespace VRF
{
    public class Player : Singleten<Player>
    {
        private Player() { }

        private PlayerObj PlayerObj;

        private string SavePath = Application.persistentDataPath + "SaveData.json";

        public void GetPlayerObj()
        {
            string data = GetJSONstring();
            PlayerObj = data == "FirstTime" ? new PlayerObj() : JsonUtility.FromJson<PlayerObj>(data);
        }

        private string GetJSONstring()
        {
            FileStream file;

            if (File.Exists(SavePath))
            {
                file = File.OpenRead(SavePath);
            }
            else
            {
                return "FirstTime";
            }

            BinaryReader binaryReader = new BinaryReader(file);
            string RawData = binaryReader.ReadString();
            binaryReader.Close();
            file.Close();
            return RawData;
        }

        public void SavePlayerObj()
        {
            FileStream file = File.Exists(SavePath) ? File.OpenWrite(SavePath) : File.Create(SavePath);
            BinaryWriter binaryWriter = new BinaryWriter(file);
            binaryWriter.Write(JsonUtility.ToJson(PlayerObj));
            binaryWriter.Close();
            file.Close();
        }

        public void SavePlayerObjectAndQuit()
        {
            SavePlayerObj();
            Application.Quit();
        }

        public void AddItem(GameObject gameObject)
        {
            PlayerObj.Inventory.Add(gameObject);
        }

        public void RemoveItem(GameObject gameObject)
        {
            PlayerObj.Inventory.Remove(gameObject);
        }

        public void RemoveItem(int index)
        {
            PlayerObj.Inventory.RemoveAt(index);
        }

        public void RemoveAllFish()
        {
            PlayerObj.Inventory.RemoveRange(0, PlayerObj.Inventory.Count);
        }

        public void SetCurrent_S_Bait(GameObject gameObject)
        {
            PlayerObj.Current_S_Bait = gameObject;
        }

        public void SetCurrent_M_Bait(GameObject gameObject)
        {
            PlayerObj.Current_M_Bait = gameObject;
        }

        public void SetCurrent_L_Bait(GameObject gameObject)
        {
            PlayerObj.Current_L_Bait = gameObject;
        }

        public GameObject Get_S_Bait()
        {
            return PlayerObj.Current_S_Bait;
        } 

        public GameObject Get_M_Bait()
        {
            return PlayerObj.Current_M_Bait;
        }
        public GameObject Get_L_Bait()
        {
            return PlayerObj.Current_L_Bait;
        }
    }
}

