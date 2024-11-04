using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletChange : MonoBehaviour
{
    [SerializeField] Material bulletMaterial;
    [SerializeField] Color [] colors;
    public static event Action OnColectedItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
