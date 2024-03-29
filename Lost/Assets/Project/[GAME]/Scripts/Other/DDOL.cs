using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
{
    public List<GameObject> DontDestroyObjects = new();

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
