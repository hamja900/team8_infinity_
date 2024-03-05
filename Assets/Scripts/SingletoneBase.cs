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
                i = FindObjectOfType<T>();
                if (i == null)
                {
                    i = new GameObject(typeof(T).FullName).AddComponent<T>();
                }
            }
            return i;
        } 
    }
}
