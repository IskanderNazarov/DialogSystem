using UnityEngine;

public class GameManager : MonoBehaviour {

    public MainMenu mainMenu;
    public DialogPlayer dialogPlayer;

    [SerializeField] private DialogConfig barbyConfig;
    [SerializeField] private DialogConfig loveStoryConfig;
    [SerializeField] private DialogConfig thinkerConfig;
    

    private void playDialog(DialogConfig dialogConfig) {
        dialogPlayer.showDialog(dialogConfig, onDialogFinished);
        mainMenu.hideMenu();
    }

    private void onDialogFinished() {
        mainMenu.showMenu();
    }

    public void barbyDialogClicked() {
        playDialog(barbyConfig);
    }

    public void loveStoryDialogClicked() {
        playDialog(loveStoryConfig);
    }

    public void thinkerDialogClicked() {
        playDialog(thinkerConfig);
    }
}