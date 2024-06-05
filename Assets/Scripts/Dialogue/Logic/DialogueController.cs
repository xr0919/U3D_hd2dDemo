using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DialogueController : MonoBehaviour
    {
    
        public UnityEvent OnFinishEvent;
        public List<DialoguePiece> dialogueList = new List<DialoguePiece>();

        private Stack<DialoguePiece> dailogueStack;

        private bool canTalk;
        private bool isTalking;
        //private GameObject uiSign;

        private DialogueUI dialogueUI;
        private GameObject dialogPanel;
        private RectTransform dialogueRectTransform;

        private void Awake()
        {
            //uiSign = transform.GetChild(1).gameObject;
            FillDialogueStack();
        }
        private void Start()
        {
            dialogueUI = GameObject.FindObjectOfType<DialogueUI>();
            
        }

    private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //canTalk = !npc.isMoving && npc.interactable;
                canTalk = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                canTalk = false;
                dialogueUI.dialogueBox.SetActive(false);
            }
        }

        private void Update()
        {
            dialogPanel = GameObject.Find("DialogPanel");
            if (dialogPanel != null ) dialogueRectTransform = dialogPanel.GetComponent<RectTransform>();
            //uiSign.SetActive(canTalk);
            

            if (canTalk & Input.GetKeyDown(KeyCode.Space) && !isTalking)
                {
                    StartCoroutine(DailogueRoutine());
                    //世界坐标转屏幕坐标
                    Vector3 npcW2S = Camera.main.WorldToScreenPoint(this.transform.position);
                    Vector3 tempV = new Vector3(npcW2S.x - 120, npcW2S.y + 90, npcW2S.z);
                    if (dialogueRectTransform != null)
                    {
                        dialogueRectTransform.position = tempV;
                    }
                }
        }

        /// <summary>
        /// 构建对话堆栈
        /// </summary>
        private void FillDialogueStack()
        {
            dailogueStack = new Stack<DialoguePiece>();
            for (int i = dialogueList.Count - 1; i > -1; i--)
            {
                dialogueList[i].isDone = false;
                dailogueStack.Push(dialogueList[i]);
            }
        }

        private IEnumerator DailogueRoutine()
        {
            isTalking = true;
            if (dailogueStack.TryPop(out DialoguePiece result))
            {
                //传到UI显示对话
                EventHandler.CallShowDialogueEvent(result);
                //EventHandler.CallUpdateGameStateEvent(GameState.Pause);
                yield return new WaitUntil(() => result.isDone);
                isTalking = false;
            }
            else
            {
                //EventHandler.CallUpdateGameStateEvent(GameState.Gameplay);
                EventHandler.CallShowDialogueEvent(null);
                FillDialogueStack();
                isTalking = false;

                if (OnFinishEvent != null)
                {
                    OnFinishEvent.Invoke();
                    canTalk = false;
                }
            }
        }
    
    }
