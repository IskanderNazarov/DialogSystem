using System;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Config", menuName = "Dialog config", order = 0)]
public class DialogConfig : ScriptableObject {
    public Sprite iconLeft;
    public Sprite iconRight;
    public PhraseContainer[] phrases;
}

[Serializable]
public class PhraseContainer {
    [FormerlySerializedAs("isForLeftPerson")] public bool isLeftPerson;
    public string phrase;
}