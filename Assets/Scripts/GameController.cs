using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static Action OnWin = delegate { };
    public static Action OnNextLevel = delegate { };

    private int _remainigBlocks;
    private int _currentLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        BlockController.OnBlockDestroy += BlockDestroy;
        _remainigBlocks = LevelGenerator.AmountBlocks;
    }

    public void BlockDestroy() 
    {
        _remainigBlocks--;

        if (_remainigBlocks <= 0) 
        {

            _currentLevel++;

            if (_currentLevel <= LevelGenerator.AmountLevel)
            {
                OnNextLevel();
                _remainigBlocks = LevelGenerator.AmountBlocks;
            }
            else
            {
                OnWin();
            }
        }
    }

    private void OnDestroy()
    {
        BlockController.OnBlockDestroy -= BlockDestroy;
    }
}
