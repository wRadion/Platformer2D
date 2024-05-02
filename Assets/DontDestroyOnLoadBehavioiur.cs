using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadBehavioiur : MonoBehaviour
{
    public static Dictionary<string, DontDestroyOnLoadBehavioiur> Instances = new Dictionary<string, DontDestroyOnLoadBehavioiur>();

    public bool Singleton;
    public string SingletonKey;

    private void Awake()
    {
        if (Singleton)
        {
            if (Instances.ContainsKey(SingletonKey))
            {
                Destroy(gameObject);
                return;
            }
            Instances[SingletonKey] = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
