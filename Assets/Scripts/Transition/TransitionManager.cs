using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public string startSceneName = string.Empty;
    [SerializeField]
    private CanvasGroup fadeCanvasGroup;
    private bool isFade;


    private void OnEnable()
    {
        EventHandler.TransitionEvent += OnTransitionEvent;
    }

    private void OnDisable()
    {
        EventHandler.TransitionEvent -= OnTransitionEvent;
    }


    private void Start()
    {
        //fadeCanvasGroup = GameObject.FindGameObjectWithTag("CursorCanvas").transform.GetChild(1).GetComponent<CanvasGroup>();
        StartCoroutine(LoadSceneSetActive(startSceneName));

    }


    private void OnTransitionEvent(string sceneToGo, Vector3 positionToGo)
    {
        StartCoroutine(Transition(sceneToGo, positionToGo));
    }

    /// <summary>
    /// �����л�
    /// </summary>
    /// <param name="sceneName">Ŀ�곡��</param>
    /// <param name="targetPosition">Ŀ��λ��</param>
    /// <returns></returns>
    private IEnumerator Transition(string sceneName, Vector3 targetPosition)
    {
        EventHandler.CallBeforeSceneUnloadEvent();

        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        yield return LoadSceneSetActive(sceneName);
        //�ƶ���������
        EventHandler.CallMoveToPosition(targetPosition);
        EventHandler.CallAfterSceneLoadedEvent();
    }

    /// <summary>
    /// ���س���������Ϊ����
    /// </summary>
    /// <param name="sceneName">������</param>
    /// <returns></returns>
    private IEnumerator LoadSceneSetActive(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);

        SceneManager.SetActiveScene(newScene);
    }


}