using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
namespace Solution
{
    public class ActionHistoryManager : MonoBehaviour
    {
        // 1. Undo System using Stack
        private Stack<Vector2> undoStack = new Stack<Vector2>();
        private Stack<Vector2> redoStack = new Stack<Vector2>();
        // 2. Auto-Move System using Queue
        private Queue<Vector2> autoMoveQueue = new Queue<Vector2>();

        #region "This Is undoStack Function"

        /// Saves the current player state (position) to the undo stack.
        public void SaveStateForUndo(Vector2 currentPosition)
        {
            // Only push a state if it's different from the last saved state 
            // (optional optimization, but good practice for movement)
            if (undoStack.Count == 0 || !undoStack.Peek().Equals(currentPosition))
            {
                undoStack.Push(currentPosition);
                if (redoStack.Count > 0)
                {
                    redoStack.Clear();
                }
            }
            
            
            undoStack.Push(currentPosition);    
        }
        /// Reverts the player's state to the previous one using the undo stack.
        /// </summary>
        public void UndoLastMove(OOPPlayer player)
        {
            // Need at least two states: the current one, and the one to revert to.
            if (undoStack.Count > 1)
            {
                Vector2 currentPos = undoStack.Pop();
                redoStack.Push(currentPos);

                Vector2 previousPos = undoStack.Peek();

                transform.position = previousPos;

                int toX = (int)transform.position.x;
                int toY = (int)transform.position.y;
                player.UpdatePosition(toX, toY);
            }
        }
        public void RedoLastMove(OOPPlayer player)
        {
            // Need at least two states: the current one, and the one to revert to.
            if (redoStack.Count > 0)
            {
                Vector2 PosRedo = redoStack.Pop();
                undoStack.Push(PosRedo);

                transform.position = PosRedo;

                int toX = (int)transform.position.x;
                int toY = (int)transform.position.y;
                player.UpdatePosition(toX, toY);
            }
        }
        #endregion

        #region "This Is autoMoveQueue Function"

        public void StartAutoMoveSequence(OOPPlayer player)
        {
            //create a sample sequence of moves
            // 1. prepare the Queue with the sequence of moves
            autoMoveQueue.Clear();

            autoMoveQueue.Enqueue(Vector2.right);
            autoMoveQueue.Enqueue(Vector2.right);
            autoMoveQueue.Enqueue(Vector2.right);
            autoMoveQueue.Enqueue(Vector2.right);
            autoMoveQueue.Enqueue(Vector2.right);
            autoMoveQueue.Enqueue(Vector2.up);
            autoMoveQueue.Enqueue(Vector2.up);
            autoMoveQueue.Enqueue(Vector2.up);
            autoMoveQueue.Enqueue(Vector2.up);
            autoMoveQueue.Enqueue(Vector2.up);
            autoMoveQueue.Enqueue(Vector2.up);
            autoMoveQueue.Enqueue(Vector2.right);
            autoMoveQueue.Enqueue(Vector2.right);


            // Start the coroutine to process the auto-move sequence
            StartCoroutine(ProcessAutoMoveSequence(player));
        }
        public IEnumerator ProcessAutoMoveSequence(OOPPlayer player)
        {
            player.isAutoMoving = true;
            Debug.Log($"Auto-move sequence started with {autoMoveQueue.Count} steps.");

            while( autoMoveQueue.Count > 0 )
            {
                Vector2 nextDirection = autoMoveQueue.Dequeue();
                player.Move( nextDirection );
                // 2. process the Queue step-by-step
                yield return new WaitForSeconds(0.5f); // Initial delay before starting
            }
            

            player.isAutoMoving = false;
            Debug.Log("Auto-move sequence finished.");
        }

        #endregion

    }
}

