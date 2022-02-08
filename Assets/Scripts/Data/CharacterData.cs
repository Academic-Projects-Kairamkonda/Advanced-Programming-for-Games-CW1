using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/Character Data", order = 1)]
public class CharacterData : ScriptableObject
{
    /// <summary>
    /// bodydata base for the bodyParts.
    /// </summary>
    public List<bodyObject> bodyData;
}

[System.Serializable]
public class bodyObject
{
    public string Name;
    public List<Sprite> sprites = new List<Sprite>();
    public int count = 0;
}