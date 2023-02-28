using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Numbers;
public class MyArray<T> : List<T> where T : ANumber<T>
{
    public MyArray(List<T> Other): base(Other)
    { 
            
    }
        
    public static implicit operator MyArray<T> (T[] l)
    {
       return new MyArray<T> (new List<T>(l));
    }
     

    public static MyArray<T>  operator + (MyArray<T>  Left, MyArray<T>  Right)
        {
        MyArray<T> Copy = new MyArray<T> (Left);

            for (int i = 0; i < Left.Count; i++)
            {
                Left[i].Add(Right[i]);
            }

            return Left;
        }


   
     public MyArray(int capacity = 0,T Initialize = null) : base(capacity)
    {
        
        for (int i = 0; i < capacity; i++)
        {
             Add(Initialize);
        }
        
      
    }


    public MyArray(T[] jagged) : base(jagged) { }

 


    public T this[uint index] { get { return this[(int)index]; } set { this[(int)index] = value; } }

    public static MyArray<T> operator +(MyArray<T> arr1, List<T> arr2)
    {
        MyArray<T> arr = new MyArray<T>(arr1);

        for (int i = 0; i < arr1.Count; i++)
        {
            arr[i].Add(arr2[i]);
        }
        return arr;
    }

    public static MyArray<T> operator *(MyArray<T> arr1, List<T> arr2)
    {
        MyArray<T> arr = new MyArray<T>(arr1);

        for (int i = 0; i < arr1.Count; i++)
        {
            arr[i].Multiply(arr2[i]);
        }
        return arr;
    }

    public static MyArray<T> operator -(MyArray<T> arr1, List<T> arr2)
    {
        MyArray<T> arr = new MyArray<T>(arr1);

        for (int i = 0; i < arr1.Count; i++)
        {
            arr[i].Subtract(arr2[i]);
        }
        return arr;
    }

    public static MyArray<T> operator /(MyArray<T> arr1, List<T> arr2)
    {
        MyArray<T> arr = new MyArray<T>(arr1);

        for (int i = 0; i < arr1.Count; i++)
        {
            arr[i].Divide(arr2[i]);
        }
        return arr;
    }


    public static MyArray<T> operator *(MyArray<T> arr1, T n)
    {
        MyArray<T> arr = new MyArray<T>(arr1);

        for (int i = 0; i < arr1.Count; i++)
        {
            arr[i].Multiply(n);
        }
        return arr;
    }


    public int ArgMax
    {
        get
        {
            int j = 0;
            T Max = this[j];
            for (int i = 1; i < Count; i++)
            {
                if (this[i].toDouble > Max.toDouble)
                {
                    Max = this[i];
                    j = i;
                }
            }

            return j;
        }
    }

    public void randomize()
    {
        for (int i = 0; i < Count; i++)
        {
            this[i].toDouble = Random.Shared.NextSingle();
        }
    }
    public string toString
    {
        get
        {
            string s = "MyArray<T>{ ";
            ForEach(x => s += x + ", ");
            s += " }";
            return s;
        }
    }

}

 
