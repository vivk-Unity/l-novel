using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] private Image _image;

    private float _deltaAlpha;
    private float _startValue;
    private float _endValue;
    private bool _isRunning;

    public void SetAlpha(float alpha)
    {
        var color = _image.color;
        color.a = alpha;
        _image.color = color;
    }
    
    public void FadeIn(float delay)
    {
        Fade(start: _image.color.a,
            end: 1,
            delay: delay);
    }

    public void FadeOut(float delay)
    {
        Fade(start: _image.color.a,
            end: 0,
            delay: delay);
    }

    private void Fade(float start, 
        float end, 
        float delay)
    {
        if (_image == null)
        {
            Debug.LogError("Renderer not found!", this);
            return;
        }

        _deltaAlpha = (end - start) / delay;
        _startValue = start;
        _endValue = end;
        _isRunning = true;
    }
    
    private void Start()
    {
        if (_image == null)
            _image = GetComponent<Image>();
        
        CustomUpdate.Instance.SubscribeFixedUpdate(this, 
            CustomFixedUpdate);
        
        _isRunning = false;
    }

    private void CustomFixedUpdate(float deltaTime)
    {
        if (_isRunning == false)
            return;

        var color = _image.color;
        color.a += (_deltaAlpha * deltaTime);
        if (color.a > 1 ||
            color.a < 0)
        {
            color.a = _endValue;
            _isRunning = false;
        }
        
        _image.color = color;
        
        
    }
}
