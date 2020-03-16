using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayTwoSides
{
    public class ArrayTwoSides<T>
    {
        private T[] array;
        private T[] arrayMinus;
        /**
         * To construct usually array
         */
        public ArrayTwoSides(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("size < 0");
            }
            array = new T[size];
            arrayMinus = new T[0];
        }
        /**
         * To construct array with items number less than zero
         * indexBegin must be less than zero or equal zero
         */
        public ArrayTwoSides(int size, int indexBegin)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("size < 0");
            }
            if (indexBegin > 0)
            {
                throw new ArgumentOutOfRangeException("indexBegin > 0");
            }
            array = new T[size + indexBegin];
            arrayMinus = new T[(-1) * indexBegin];
        }

        public T Get(int index)
        {
            if (index >= array.Length || index < (-1)*arrayMinus.Length)
            {
                throw new IndexOutOfRangeException("index = " + index);
            }
            else if (index < 0)
            {
                return arrayMinus[(-1) * index - 1];
            }
            else
            {
                return array[index];
            }
        }

        public void Set(int index, T value)
        {
            if (index < 0)
            {
                if(index < (-1)*arrayMinus.Length)
                {
                    ResizeMinus((-1) * index);
                }
                arrayMinus[(-1)*index - 1] = value;
            }
            if (index >= 0)
            {
                if (index >= array.Length)
                {
                    Resize(index + 1);
                }
                array[index] = value;
            }
        }
        protected void Resize(int size)
        {
            T[] newArray = new T[size];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }
        protected void ResizeMinus(int size)
        {
            T[] newArray = new T[size];
            for (int i = 0; i < arrayMinus.Length; i++)
            {
                newArray[i] = arrayMinus[i];
            }
            arrayMinus = newArray;
        }
        public int Length
        {
            get
            {
                return array.Length + arrayMinus.Length;
            }
        }
        public int indexBegin
        {
            get { return (-1) * arrayMinus.Length; }
        }
        public int indexEnd
        {
            get { return array.Length - 1; }
        }

    }
}
