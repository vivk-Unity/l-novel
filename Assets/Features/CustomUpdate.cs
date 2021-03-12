using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomUpdate : MonoBehaviour
{
    private Dictionary<MonoBehaviour, Action<float>> _update;
    private Dictionary<MonoBehaviour, Action<float>> _fixedUpdate;

    private static CustomUpdate _instance;

    public static CustomUpdate Instance => _instance;

    public void SubscribeUpdate(MonoBehaviour root, 
        Action<float> method)
    {
        if (_update.ContainsValue(method) == true)
            return;
        
        _update.Add(root, method);
    }
    
    public void SubscribeFixedUpdate(MonoBehaviour root, 
        Action<float> method)
    {
        if (_fixedUpdate.ContainsValue(method) == true)
            return;
        
        _fixedUpdate.Add(root, method);
    }    
    private void Awake()
    {
        if (_instance != null && 
            _instance != this)
        {
            Destroy(this.gameObject);
        } 
        else 
        {
            _instance = this;
        }
    }

    private void Update()
    {
        var deltaTime = Time.deltaTime;
        foreach (var method in _update.Values)
        {
            method.Invoke(deltaTime);
        }
    }

    private void FixedUpdate()
    {
        var deltaTime = Time.fixedDeltaTime;
        foreach (var method in _fixedUpdate.Values)
        {
            method.Invoke(deltaTime);
        }
    }
}
