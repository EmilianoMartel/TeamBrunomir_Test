using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public List<string> choise;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
