using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] 
    private LevelManager _levelManager;
    
    [SerializeField] 
    private TextMeshProUGUI _question;

    [SerializeField] 
    private Image _restartScreen;
    
    [SerializeField] 
    private Canvas _LoadingCanvas;
    
    [SerializeField] 
    private Image _LoadingScreen;

    [SerializeField] 
    private Canvas _restartCanvas;
    public void SetQuestion(string answer)
    {
        _question.text = "Find " + answer;
    }

    public void OpenRestartScreen()
    {
        _restartCanvas.gameObject.SetActive(true);
        _restartScreen.DOFade(0.8f, 1f);
    }
    public void CloseRestartScreen()
    {

        _restartScreen.DOFade(0.0f, 1f).onComplete+= () => _restartCanvas.gameObject.SetActive(false);
    }

    public void TextFadeIn()
    {
        _question.DOFade(0f, 0f);
        _question.DOFade(1f, 2f);
    }

    public void StartLoading()
    {
        _LoadingCanvas.gameObject.SetActive(true);
        _LoadingScreen.DOFade(1f, 1f).onComplete += () =>
        {
            _levelManager.StartFirstLevel();
            _LoadingScreen.DOFade(0.0f, 0.2f);
            _LoadingCanvas.gameObject.SetActive(false);
        };
    }
}
