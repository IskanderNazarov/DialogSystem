using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogPersonIcon : MonoBehaviour {
    [SerializeField] private Image icon;

    private bool isActive;
    private DialogSettings dialogSettings;

    private Transform tr;
    private Vector2 originScale;
    private bool isInit;

    private void init() {
        tr = transform;
        originScale = tr.localScale;
    }

    public void setup(Sprite iconSprite, DialogSettings settings) {
        if (!isInit) init();
        dialogSettings = settings;

        icon.sprite = iconSprite;
        isActive = false;
    }

    public void activate(bool activate) {
        isActive = activate;
        tr.localScale = originScale;
        timer = 0;
    }

    private float timer;
    private void Update() {
        if (!isActive) return;

        var t = 1 + Mathf.PingPong(timer, dialogSettings.iconAnimScaleFactor);
        tr.localScale = originScale * t;
        timer += Time.deltaTime * dialogSettings.iconAnimSpeed;
    }
}