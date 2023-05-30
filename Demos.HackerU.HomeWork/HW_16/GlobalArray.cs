using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.HackerU.HomeWork.HW_16
{
    public class GlobalArray<T>
    {
        public T[] array;

        public event EventHandler <GlobalArrayEventArgs<T>> AddOrUpdateEvent;

        public GlobalArray(int fixSize) 
        { 
           array = new T[fixSize];
        }


        public void AddOrUpdate(int index, T item)
        {

            array[index] = item;
            AddOrUpdateEvent.Invoke(this, new GlobalArrayEventArgs<T>(index,item));

        }

        public T GetData(int index)
        {
            return array[index];
        }
    }

    public class GlobalArrayEventArgs<T> : EventArgs
    {
        public T Item { get; set; }
        public int Index { get; set; }

        public GlobalArrayEventArgs(int index ,T item)
        {
            Item = item;
            Index = index;
        }
    }
}
