using System;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class DialogPlayer : MonoBehaviour {
    [FormerlySerializedAs("displayingConfig")] [SerializeField] private DialogSettings settings;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private DialogPersonIcon iconLeft;
    [SerializeField] private DialogPersonIcon iconRight;


    private Action onDialogFinished;
    private DialogConfig phrasesConfig;
    private bool isAnimating;
    private int phraseIndex;
    private Coroutine textAnimatingCoroutine;

    private WaitForSeconds waitForSeconds;

    public void showDialog(DialogConfig config, Action onDialogFinishedCallback = null) {
        iconLeft.setup(config.iconLeft, settings);
        iconRight.setup(config.iconRight, settings);
        
        onDialogFinished = onDialogFinishedCallback;
        gameObject.SetActive(true);
        this.phrasesConfig = config;
        waitForSeconds = new WaitForSeconds(settings.phraseAnimInterval);

        phraseIndex = 0;
        playPhrase(phraseIndex);
    }

    public void hideDialog() {
        gameObject.SetActive(false);
    }

    private void playPhrase(int index) {
        var phrase = phrasesConfig.phrases[index];

        isAnimating = true;
        textAnimatingCoroutine = StartCoroutine(animateText(phrase));
        
        iconLeft.activate(phrase.isLeftPerson);
        iconRight.activate(!phrase.isLeftPerson);
    }

    private IEnumerator animateText(PhraseContainer phraseContainer) {
        var message = phraseContainer.phrase;
        var messageBuffer = new StringBuilder();
        var letterIndex = 0;
        while (messageBuffer.Length != message.Length) {
            messageBuffer.Append(message[letterIndex]);
            letterIndex++;
            updateTextUI(messageBuffer.ToString());

            yield return waitForSeconds;
        }

        onPhraseAnimatingFinished();
    }

    public void dialogClicked() {
        if (isAnimating) {
            StopCoroutine(textAnimatingCoroutine);
            onPhraseAnimatingFinished();
            return;
        }

        if (phraseIndex < phrasesConfig.phrases.Length) {
            playPhrase(phraseIndex);
        }
        else {
            onDialogFinished?.Invoke();
            onDialogFinished = null;
            hideDialog();
        }
    }

    private void onPhraseAnimatingFinished() {
        updateTextUI(phrasesConfig.phrases[phraseIndex].phrase);
        isAnimating = false;
        phraseIndex++;
        
        iconLeft.activate(false);
        iconRight.activate(false);
    }

    private void updateTextUI(string message) {
        dialogText.text = message;
    }
}