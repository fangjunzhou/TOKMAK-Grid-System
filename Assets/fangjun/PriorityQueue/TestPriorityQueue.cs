using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace fangjun.PriorityQueue
{
    public class TestPriorityQueue : MonoBehaviour
    {
        #region Public Field
        public TMP_Text text;
        public TMP_InputField inputString;
        public TMP_InputField inputPriority;
        #endregion

        #region Private Field
        private PriorityQueue<string> priorityQueue = new PriorityQueue<string>();
        #endregion

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            text.text = priorityQueue.ToString();
        }

        #region Public Methods
        public void Push()
        {
            priorityQueue.Push(new PriorityQueueNode<string>()
            {
                data = inputString.text,
                priority = int.Parse(inputPriority.text)
            });
        }

        public void Pop()
        {
            Debug.Log(priorityQueue.Pop());
        }
        #endregion
    }
}