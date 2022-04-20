using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameResult : MonoBehaviour
{
    [SerializeField]
    private Image _gameResult;

    [SerializeField]
    private Sprite[] _spiteResult;

    [SerializeField]
    private GameObject _ball;

    private void Start()
    {
        Lose.OnLose += Loses;
        GameController.OnWin += Win;
    }

    public void Loses()
    {
        _gameResult.sprite = _spiteResult[0];
        _gameResult.gameObject.SetActive(true);
        Destroy(_ball);
        StartCoroutine(NewGame());
    }

    public void Win() 
    {
        _gameResult.sprite = _spiteResult[1];
        _gameResult.gameObject.SetActive(true);
        Destroy(_ball);
        StartCoroutine(NewGame());
    }

    private void OnDestroy()
    {
        Lose.OnLose -= Loses;
        GameController.OnWin -= Win;
    }

    private IEnumerator NewGame() 
    {
        yield return new WaitForSeconds(2f);

        _gameResult.gameObject.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
}
