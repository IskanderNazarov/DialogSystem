using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Dialogs displaying config", order = 0)]
public class DialogSettings : ScriptableObject {

    public float phraseAnimInterval = 0.1f;
    public float iconAnimScaleFactor = 0.1f;
    public float iconAnimSpeed = 1;

}