using DataSync;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace LabDataCollector
{
    public class LabTools
    {

        public static T GetData<T>(LabDataBase data) where T : LabDataBase
        {
            return data is T @base ? @base : null;
        }

        public static string DataPath => Application.dataPath;
        /// <summary>
        /// 创建存储数据的文件夹
        /// </summary>
        /// <param name="floderName"></param>
        /// <param name="isNew"></param>
        public static string CreatSaveDataFolder(string floderName, bool isNew = false)
        {
            if (Directory.Exists(floderName))
            {
                if (isNew)
                {
                    var tempPath = floderName + "_" + DateTime.Now.Millisecond.ToString();
                    Directory.CreateDirectory(tempPath);
                    return tempPath;
                }

                Debug.Log("Folder Has Existed!");
                return floderName;
            }
            else
            {
                Directory.CreateDirectory(floderName);
                Debug.Log("Success Create: " + floderName);
                return floderName;
            }
        }
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="path"></param>
        public static void CreatData(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                Debug.Log("Success Create: " + path);
            }
        }


        /// <summary>
        /// 根据Config类型反序列化，如果是需要覆盖旧的config，传入true
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isNew"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T GetConfig<T>(bool isNew = false, string filePath = "/Configs") where T : class, new()
        {
            var path = DataPath + filePath + "/" + "LabDataCollectorConfigData";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = path + "/" + typeof(T).Name + ".json";


            if (isNew && File.Exists(path))
            {
                File.Delete(path);
            }
            if (!File.Exists(path))
            {
                var json = JsonConvert.SerializeObject(new T());
                var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(json);
                sw.Close();
            }

            StreamReader sr = new StreamReader(path);
            var data = JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
            sr.Close();
            return data;
        }
    }
}

