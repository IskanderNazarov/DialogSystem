using UnityEngine;

public class MainMenu : MonoBehaviour {
    public void showMenu() {
        gameObject.SetActive(true);
    }

    public void hideMenu() {
        gameObject.SetActive(false);
    }
}