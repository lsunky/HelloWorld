using Excel;
using LitJson;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AppConfig;
public class AppMain
{
    static void Main(string[] args)
    {
        //string configName = "AccessoryConfigSheet";
        //FileStream stream1 = File.Open(AppConst.binRoot + configName + ".bin", FileMode.Open, FileAccess.Read);
        //string readText = File.ReadAllText("d:/test/json/AccessoryConfig.json");
        //DateTime startTime = DateTime.Now;
        //Console.WriteLine("ReadBin start");
        //ReadBin(configName,stream1);
        //Console.WriteLine("ReadBin end  "+ (DateTime.Now - startTime).TotalMilliseconds);

        //startTime = DateTime.Now;
        //Console.WriteLine("ReadJson start");
        //ReadJson(readText);
        //Console.WriteLine("ReadJson end  " + (DateTime.Now - startTime).TotalMilliseconds);

        //Console.ReadKey();
        //return;

        FileStream stream = File.Open(AppConst.excelContent +"AccessoryConfig.xlsx", FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        Console.WriteLine("excelReader.Name:" + excelReader.Name);
        
        DataSet result = excelReader.AsDataSet();
        SheetVo sheetVo = new SheetVo(result.Tables, excelReader.Name);

        ConfigProducerBase configProducer = new ConfigProducerJson();
        configProducer.ToConfig(sheetVo.fieldInfos, sheetVo.rowVoList, sheetVo.sheetName);

        ClassProducerBase classProducer = new ClassProducerCs();
        classProducer.ToClassFile(sheetVo.fieldInfos, sheetVo.sheetName);

        Console.ReadKey();
    }

    static void ReadBin(string configName,FileStream stream)
    {
       
        //for (int i = 0; i < 1000; i++)
        //{
        //    PraseBin(configName, stream);
        //}
        PraseBin(configName, new BinaryReader(stream));

    }

    static void PraseBin(string configName, BinaryReader br)
    {
        Type t = Type.GetType(configName);
        object obj;
        Dictionary<string, object> dictObj = new Dictionary<string, object>();
        FieldInfo[] fieldInfoList = t.GetFields();
        for (int i = 0, length = br.ReadInt32(); i < length; i++)
        {
            obj = Activator.CreateInstance(t);//根据类型创建实例
            bool isFirst = true;
            foreach (FieldInfo info in fieldInfoList)
            {
                if (info.FieldType == typeof(string))//属性的类型判断 
                {
                    info.SetValue(obj, br.ReadString());
                }
                else if (info.FieldType == typeof(int))
                {
                    info.SetValue(obj, br.ReadInt32());
                }
                else if (info.FieldType == typeof(bool))
                {
                    info.SetValue(obj, br.ReadBoolean());
                }
                else if (info.FieldType == typeof(double))
                {
                    info.SetValue(obj, br.ReadDouble());
                }

                if (isFirst)
                {
                    dictObj.Add(info.GetValue(obj).ToString(), obj);
                    isFirst = false;
                }
            }
        }
    }

    static void ReadJson(string json)
    {
        PraseJson(json);
    }

    static void PraseJson(String json)
    {
        Dictionary<string, AccessoryConfigSheet> dictObj = new Dictionary<string, AccessoryConfigSheet>();
        JsonData data = JsonMapper.ToObject(json);
        foreach (string key in data.Keys)
        {
            string dataStr = data[key].ToJson();

            AccessoryConfigSheet t = JsonMapper.ToObject<AccessoryConfigSheet>(dataStr);
            dictObj.Add(key, t);
        }
    }
}
