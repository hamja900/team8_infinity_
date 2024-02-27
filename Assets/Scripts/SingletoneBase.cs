using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletoneBase<T> : MonoBehaviour where T : MonoBehaviour
{
    static T i;
    public static T I 
    { get
        {
            if (i == null)
            {
                GameObject temp = new GameObject();
                i = temp.AddComponent<T>();
            }
            return i;
        } 
    }
}
