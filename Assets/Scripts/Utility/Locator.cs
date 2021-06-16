using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyUtility
{
    public class Locator<T>
    {
        private static Dictionary<int, T> instancesDic = new Dictionary<int, T>(1);//最初に確保しておくメモリの領域
        public static bool IsExists()//入ってるかどうかの確認
        {
            return instancesDic.Count > 0;
        }
        public static void Bind(T instance, int id = 0)
        {
            instancesDic[id] = instance;
        }
        public static void UnBind(int id = 0)
        {
            instancesDic[id] = default;
        }
        public static void UnBindAll()
        {
            instancesDic.Clear();
        }
        public static T GetT(int id = 0)
        {
            if (!instancesDic.ContainsKey(id)) return default;
            return instancesDic[id];
        }
    }
}
