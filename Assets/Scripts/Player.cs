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

        public void InitPlayerObj()
        {
            string data = GetJSONstring();
            PlayerObj = data == "FirstTime" ? new PlayerObj() : JsonUtility.FromJson<PlayerObj>(data);
            Debug.Log("== (Player): InitPlayerObj");
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
                Debug.Log("== (Player): GetJSONstring (FirstTime)");
                return "FirstTime";
            }

            BinaryReader binaryReader = new BinaryReader(file);
            string RawData = binaryReader.ReadString();
            binaryReader.Close();
            file.Close();
            Debug.Log("== (Player): " + RawData);
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
            Application.Quit(0);
        }

        public void AddItem(GameObject gameObject)
        {
            PlayerObj.Inventory.Add(gameObject);
        }

        public void RemoveFish(GameObject gameObject)
        {
            if (gameObject.tag.Equals("Fish"))
            {
                AddBalance((int)gameObject.GetComponent<Fish>().Size * 100);
            }
            PlayerObj.Inventory.Remove(gameObject);
        }

        public void RemoveFish(int index)
        {
            if (PlayerObj.Inventory[index].tag.Equals("Fish"))
            {
                AddBalance((int)PlayerObj.Inventory[index].GetComponent<Fish>().Size * 100);
            }
            PlayerObj.Inventory.RemoveAt(index);
        }

        public void RemoveAllFish()
        {
            for (int i = 0; i < PlayerObj.Inventory.Count; i++)
            {
                if(PlayerObj.Inventory[i].tag.Equals("Fish"))
                    AddBalance((int)PlayerObj.Inventory[i].GetComponent<Fish>().Size * 100);
            }
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

        public int GetBalance()
        {
            return PlayerObj.Balance;
        }

        public void AddBalance(int amongs)
        {
            PlayerObj.Balance += amongs;
        }

        public void SubtractBalance(int amongs)
        {
            PlayerObj.Balance -= amongs;
        }

        public List<GameObject> GetInventory()
        {
            return this.PlayerObj.Inventory;
        }
    }
}

