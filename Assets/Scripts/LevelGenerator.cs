using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[Serializable]
public struct Row 
{
    public List<int> row;
}

[Serializable]
public class LevelData
{
    public List<string> jlevel = new List<string>();
}

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private TextAsset _levelData;

    [SerializeField]
    private GameObject[] _blocks;

    private GameObject _block;

    [SerializeField]
    private GameObject _ball;

    private Vector2 _startPosBall;

    [SerializeField]
    public LevelData rows = new LevelData();

    [SerializeField]
    private int _amountColumns = 13;

    private int _amountLines;

    private static int _amountLevel;
    public static int AmountLevel 
    {
        get => _amountLevel;
    }

    private int _numberLevel = 1;

    private static int _amountBlocks;
    public static int AmountBlocks 
    {
        get => _amountBlocks;
    }

    private Vector2 _startPos;

   /* public void Serialize()
    {
        string levelJson =  JsonUtility.ToJson(rows);

        File.WriteAllText("F:/Unity3D/Arkanoid/Assets/LevelData/LevelData.txt", levelJson);
    }
   */
    public LevelData DeSerialize()
    {
       return JsonUtility.FromJson<LevelData>(_levelData.text);
    }
   
    public void Generator(int indexLevel)
    {
        _amountBlocks = 0;

        rows = DeSerialize();

        var row = rows.jlevel[indexLevel - 1].Split(',');

        _amountLines = row.Length / _amountColumns;

        var rectTrans = _blocks[0].transform as RectTransform;
        var distance = new Vector2( rectTrans.rect.width, rectTrans.rect.height);

        _startPos = new Vector2(distance.x * (_amountColumns - 1), -Camera.main.ViewportToWorldPoint(Camera.main.transform.position).y - _amountLines / 2);

        var k = row.Length;

        for (int i = 0; i < _amountLines; i++)
        {
            for (int j = 0; j < _amountColumns; j++)
            {
                var index = int.Parse(row[k - 1]);

                if (index != 0)
                {
                    _amountBlocks++;

                    _block = Instantiate(_blocks[index - 1]) as GameObject;

                    float posX = -(2 * distance.x * j ) + _startPos.x;
                    float posY = (2 * distance.y * i ) + _startPos.y;

                    _block.transform.position = new Vector2(posX, posY);
                }

                k--;
            }
        }
    }

    void Awake()
    {
        _amountLevel = rows.jlevel.Count;

       // Serialize();

        Generator(_numberLevel);
    }

    private void Start()
    {
        _startPosBall = _ball.transform.position;
        GameController.OnNextLevel += NextLevel;
    }

    public void NextLevel() 
    {
        _ball.transform.position = _startPosBall;
        _numberLevel++;

        Generator(_numberLevel);
    }

    private void OnDestroy()
    {
        GameController.OnNextLevel -= NextLevel;
    }

}
