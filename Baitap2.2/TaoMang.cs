using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap2._2
{
    class TaoMang
    {
        public static Array createArray(Type type, int length)
        {
            return Array.CreateInstance(type, length);
        }
        public static List<int> createList(Type type)
        {
            return (List<int>)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
        }
        public static ArrayList createArrayList()
        {
            return new ArrayList();
        }
    }
}
