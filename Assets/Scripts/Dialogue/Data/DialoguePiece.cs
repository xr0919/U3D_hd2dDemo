using UnityEngine;


[System.Serializable]
public class DialoguePiece
{
    //[Header("对话详情")]
    //public Sprite faceImage;
    //public bool onLeft;
    //public string name;
    [TextArea]
    public string dialogueText;
    public bool hasToPause;
    [HideInInspector] public bool isDone;
    [HideInInspector] public bool isExit;
    //结束对话后执行的事件
    public UnityEventQueueSystem afterTalkEvent;
}