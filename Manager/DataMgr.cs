using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class DataMgr
{
    //## DataTable
    public static List<SkillData> SkillTBL { get; private set; }
    public static List<ItemData> ItemTBL { get; private set; }
    public static List<UnitData> UnitTBL { get; private set; }
    public static List<MapData> MapTBL { get; private set; }

    public static void LoadCSVTable()
    {
        SkillTBL = LoadTable<SkillData>(ReadCSVFile("SkillData"));
        ItemTBL = LoadTable<ItemData>(ReadCSVFile("ItemData"));
        UnitTBL = LoadTable<UnitData>(ReadCSVFile("UnitData"));
        MapTBL = LoadTable<MapData>(ReadCSVFile("MapData"));
    }


    private static List<Dictionary<string, string>> ReadCSVFile(string fileName)
    {
        List<Dictionary<string, string>> table = new List<Dictionary<string, string>>();
        TextAsset     csv = Resources.Load<TextAsset>("CSV/" + fileName);
        StringReader  reader = new StringReader(csv.text);
        StringBuilder sb = new StringBuilder();

        //Setting
        string[] columns;   //Į����
        int index = -1;     //Į����[] �ε���
        string line;        //�� ��
        char[] chars;       //�� ���� char ���·� �ɰ� (�߰� ,�� �߶󳻱� ����)
        bool isSplit;       //�з� ���� (��� �� ������ ,�� CSV ���н�ǥ�� �����ϱ� ����)

        //Column Index
        line = reader.ReadLine(); //ù�� ������
        columns = line.Split(',');

        //Content
        while (true)
        {
            line = reader.ReadLine();
            if (line == null)
                break;

            Dictionary<string, string> data = new Dictionary<string, string>();
            chars = line.ToCharArray();
            isSplit = true;
            index = -1;

            for (int i = 0; i < chars.Length; ++i)
            {
                //������ �߰��� ,�� ������ �ʱ� ���� �Ǻ� ���� �߰�
                if (chars[i] == '\u0022') //ū����ǥ(")�� �����ڵ�
                {
                    isSplit = !isSplit;
                    continue;
                }

                if (isSplit
                    && chars[i] == '\u002C') //��ǥ(,) �����ڵ�
                {
                    data.Add(columns[++index], sb.ToString());
                    sb.Clear();
                    continue;
                }

                sb.Append(chars[i]);
            }

            //������ ������ �߰� (,�� ��� ������ �Ȱɸ�)
            data.Add(columns[++index], sb.ToString());
            table.Add(data);
            sb.Clear();
        }

        return table;
    }
    private static List<T> LoadTable<T>(List<Dictionary<string, string>> table) where T : Interface.IDataSetter, new()
    {
        List<T> list = new List<T>();
        for (int i = 0; i < table.Count; ++i)
        {
            T tData = new T();
            tData.SetTable(table[i]);
            list.Add(tData);
        }

        return list;
    }
}