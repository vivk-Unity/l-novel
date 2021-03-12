using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgController : MonoBehaviour
{
    [SerializeField] private Image _main;
    [SerializeField] private Image _temp;

    [SerializeField] private Fader _mainFader;
    [SerializeField] private Fader _tempFader;

    private Sprite _currentSprite;

    private void Run(Sprite newSprite)
    {
        if (newSprite == _currentSprite)
            return;

        ;
    }
}
