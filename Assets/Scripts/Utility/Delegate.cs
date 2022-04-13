using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegate<T> where T:Delegate<T>
{
    //// create 
    //private delegate void MDelegate(T para);
    //// Init
    //public  void Init()
    //{
    //    MDelegate mDelegate = new MDelegate(MyMethod);
    //}
    
    // protected void MyMethod(T para) { }

    //public static void Trigger(T para)
    //{
    //    mDelegate(para);
    //}

}
