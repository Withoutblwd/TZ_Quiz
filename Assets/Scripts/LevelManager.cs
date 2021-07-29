using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Spawner _spawner;

    [SerializeField] private UIManager _uiManager;
    
    [SerializeField]
    private Level[] _levels;

    private List<Level> _levelsQueue;

    DataSetsHandler _handler = new DataSetsHandler();

    void Start()
    {
        _handler.LoadCards();

        if (_levelsQueue is null || _levelsQueue.Count == 0)
        {
            LoadLevels();
        }

        StartFirstLevel();
    }
    
    

    public void NextQuiz()
    {
        if (_levelsQueue.Count != 0)
        {
            QuizData quizData = _handler.GetQuiz(_levelsQueue[0].Variants);
            _spawner.SpawnCards(quizData);
            _uiManager.SetQuestion(quizData.Answer.Identifier);
            
            _levelsQueue.RemoveAt(0);
        }
        else
        {
            Ended();
        }
    }

    void LoadLevels()
    {
        if (_levelsQueue is null || _levelsQueue.Count == 0)
        {
            
            _levelsQueue = _levels.ToList();
        }
    }

    public void StartFirstLevel()
    { 
        _uiManager.TextFadeIn();
        LoadLevels();
        NextQuiz();
        _spawner.CallAllCards();
    }

    void Ended()
    {
        _uiManager.OpenRestartScreen();
        _handler.ClearUsed();
    }
}
