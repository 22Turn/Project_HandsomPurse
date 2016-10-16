using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCSNStandard
{
    /// <summary>
    /// save類別
    /// </summary>
    public class Save
    {
        /// <summary>
        /// 索引字串
        /// </summary>
        public string GUID = "";
    }

    /// <summary>
    /// save資料類別
    /// </summary>
    public class SaveData<T> where T : Save
    {
        /// <summary>
        /// save資料列表 <索引字串, save物件>
        /// </summary>
        private Dictionary<string, T> datas = new Dictionary<string, T>();

        /// <summary>
        /// 讀取資料
        /// </summary>
        /// <param name="json">資料字串</param>
        /// <returns>true表示成功, false則否</returns>
        public bool Load(string json)
        {
            datas.Clear();

            foreach (string itor in json.Split(new char[] { '\n' }))
            {
                T data = Json.ToObject<T>(itor);

                if (data != null)
                    datas.Add(data.GUID, data);
            }//for

            return true;
        }

        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="data">資料物件</param>
        public void Add(T data)
        {
            datas[data.GUID] = data;
        }

        /// <summary>
        /// 移除資料
        /// </summary>
        /// <param name="guid">索引物件</param>
        public void Remove(Argu guid)
        {
            datas.Remove(guid);
        }

        /// <summary>
        /// 取得資料物件
        /// </summary>
        /// <param name="guid">索引物件</param>
        /// <returns>資料物件</returns>
        public Save Get(Argu guid)
        {
            return datas.ContainsKey(guid) ? datas[guid] : null;
        }

        /// <summary>
        /// 取得save列舉物件
        /// </summary>
        /// <returns>save列舉物件</returns>
        public SaveItor<T> GetItor()
        {
            return new SaveItor<T>(this);
        }

        /// <summary>
        /// 取得資料數量
        /// </summary>
        /// <returns>資料數量</returns>
        public int Count()
        {
            return datas.Count;
        }

        /// <summary>
        /// 取得索引列表
        /// </summary>
        /// <returns>索引列表</returns>
        public List<string> List()
        {
            return new List<string>(datas.Keys);
        }

        /// <summary>
        /// 將資料轉換為字串
        /// </summary>
        /// <returns>資料字串</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            datas.Values.ToList().ForEach(itor => stringBuilder.Append(Json.ToString(itor) + "\n"));

            return stringBuilder.ToString();
        }
    }

    /// <summary>
    /// save列舉類別
    /// </summary>
    public class SaveItor<T> where T : Save
    {
        /// <summary>
        /// 資料物件
        /// </summary>
        private SaveData<T> data = null;

        /// <summary>
        /// 索引列表
        /// </summary>
        private List<string> list = null;

        /// <summary>
        /// 目前位置
        /// </summary>
        private int pos = 0;

        public SaveItor(SaveData<T> data)
        {
            if (data == null)
                return;

            this.data = data;
            this.list = data.List();
            this.pos = 0;
        }

        private bool Check()
        {
            return data != null && list != null;
        }

        /// <summary>
        /// 取得save
        /// </summary>
        /// <returns>save物件</returns>
        public Save Data()
        {
            return Check() && pos < list.Count ? data.Get(list[pos]) : null;
        }

        /// <summary>
        /// 移動到下一個
        /// </summary>
        public void Next()
        {
            if (Check() && pos < list.Count)
                ++pos;
        }

        /// <summary>
        /// 取得否到結尾
        /// </summary>
        /// <returns>true表示到結尾, false則否</returns>
        public bool IsEnd()
        {
            return Check() == false || pos >= list.Count;
        }
    }
}