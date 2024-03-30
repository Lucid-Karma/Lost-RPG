using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL<T> : MonoBehaviour where T : DDOL<T>
{
    public static T Instance { get; private set; }
    public static T DDOLObject = null;

    void Awake()
    {
        if (DDOLObject == null)
        {
            DDOLObject = (T)this;
            DontDestroyOnLoad(this);
        }
        else if (this != DDOLObject)
        {
            Destroy(gameObject);
        }
    }
}

//public class DDOL : MonoBehaviour 
//{
//    public static DDOL Instance { get; private set; }
//    public static DDOL DDOLObject = null;

//    void Awake()
//    {
//        if (DDOLObject == null)
//        {
//            DDOLObject = this;
//            DontDestroyOnLoad(this);
//        }
//        else if (this != DDOLObject)
//        {
//            Destroy(gameObject);
//        }
//    }
//}
