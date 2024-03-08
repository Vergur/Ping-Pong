using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameController _gameController;
    [SerializeField] private TextMeshProUGUI _counter;

    public void ContinueGame()
    {
        _counter.transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        ChangeVisibility(false);
        for (int i = 3; i > 0; i--)
        {
            _counter.SetText(i.ToString());
            yield return new WaitForSecondsRealtime(0.5f);
            _counter.transform.DOPunchScale(Vector3.up, 0.5f, 1);
        }
        
        _counter.SetText("");
        Time.timeScale = 1;
    }
    
    public void RestartGame()
    {
        ChangeVisibility(false);
        _gameController.RestartGame();
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeVisibility(bool isActive)
    {
        _counter.DOKill();
        _counter.SetText("");
        _menu.SetActive(isActive);
    }
}
