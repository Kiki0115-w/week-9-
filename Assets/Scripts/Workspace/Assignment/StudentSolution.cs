using System;
using System.Collections.Generic;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        class Action
        {
            public string Name;
            public int Value;
        }

        #region Lecture

        public void LCT01_StackSyntax()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            // 1, 2, 3
            Debug.Log($"Count: {stack.Count}");

            var popped = stack.Pop(); //3
            Debug.Log($"Popped: {popped}");

            var top = stack.Peek(); //1, 2
            Debug.Log($"Peek: {top}");
            Debug.Log($"Count after peek: {stack.Count}");

            stack.Clear();
        }

        public void LCT02_QueueSyntax()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            //1, 2, 3
            Debug.Log($"Count: {queue.Count}");
            var dequeue = queue.Dequeue();
            Debug.Log($"Dequeue: {dequeue}");

            var front = queue.Peek();
            Debug.Log($"Peek: {front}");
            Debug.Log($"Count after dequeue: {queue.Count}");   

            queue.Clear();

        }

        public void LCT03_ActionStack()
        {
            Action action1 = new Action { Name = "Action 1" };
            Action action2 = new Action { Name = "Action 2" };
            Action action3 = new Action { Name = "Action 3" };
            Stack<Action> stack = new Stack<Action>();

            stack.Push(action1);
            stack.Push(action2);
            stack.Push(action3);

            while (stack.Count > 0)
            {
                Action act = stack.Pop();
                Debug.Log($"Executing {act.Name}");
            }
        }

        public void LCT04_ActionQueue()
        {
            Action action1 = new Action { Name = "Action 1" };
            Action action2 = new Action { Name = "Action 2" };
            Action action3 = new Action { Name = "Action 3" };
            Queue<Action> queue = new Queue<Action>();

            queue.Enqueue(action1);
            queue.Enqueue(action2);
            queue.Enqueue(action3);

            while (queue.Count > 0)
            {
                Action act = queue.Dequeue();
                Debug.Log($"Executing {act.Name}");
            }
        }
        #endregion

        #region Assignment

        public void ASN01_ReverseString(string str)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in str)
                stack.Push(c);

            string reversed = "";
            while (stack.Count > 0)
                reversed += stack.Pop();

            Debug.Log(reversed);
        }

        public void ASN02_StackPalindrome(string str)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in str)
                stack.Push(c);

            string reversed = "";
            while (stack.Count > 0)
                reversed += stack.Pop();

            if (str == reversed)
                Debug.Log("is a palindrome");
            else
                Debug.Log("is not a palindrome");
        }

        #endregion

        #region Extra

        public void EX01_ParenthesesChecker(string str)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> pairs = new Dictionary<char, char>
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            foreach (char c in str)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0 || stack.Pop() != pairs[c])
                    {
                        Debug.Log("Unbalanced");
                        return;
                    }
                }
            }

            Debug.Log(stack.Count == 0 ? "Balanced" : "Unbalanced");

        }

        #endregion
    }
}
