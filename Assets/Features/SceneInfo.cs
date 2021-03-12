using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newScene", menuName = "Custom/SceneInfo")]
public class SceneInfo : ScriptableObject
{
    [SerializeField] private TextInfo _mainText;
    [SerializeField] private CharacterInfo _mainCharacter;
    [SerializeField] private CharacterInfoContainer[] _charactersContainer;
    [SerializeField] private SceneInfo _nextScene;
    
    [Serializable]
    public class CharacterInfoContainer
    {
        public CharacterInfo Character;
        public SpriteRenderer Root;
    }
    
    
    [Serializable]
    public class TextInfo
    {
        [TextArea(5, 10)]
        public String[] Text;
    }

    public TextInfo MainText => _mainText;
    public CharacterInfo MainCharacter => _mainCharacter;
    public CharacterInfoContainer[] CharactersContainer => _charactersContainer;
    public SceneInfo NextScene => _nextScene;
}
