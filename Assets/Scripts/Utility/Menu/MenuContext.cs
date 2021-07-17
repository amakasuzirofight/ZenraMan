using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Menu
{
    public class MenuContext : MonoBehaviour
    {
        [SerializeField] List<MenuChild> children = null;
        [SerializeField] int row = 5;//s”
        [SerializeField] int column = 5; //—ñ”
        [SerializeField] bool repeatMove = true;

        public int SelectedIdx { get; private set; } = 0;
        public int ChildCount => children.Count;

        public void Select(int i)
        {
            children[SelectedIdx].DiselectedAction?.Invoke();
            SelectedIdx = i;
            children[SelectedIdx].SelectedAction?.Invoke();
        }

        public void Move(Direction dir)
        {
            int move = DirToInt(dir);
            int moved = SelectedIdx + move;

            if (moved < 0)
            {
                if (repeatMove) 
                    moved = children.Count - 1;
                else 
                    moved = 0;
            }
            else
            if(moved >= children.Count)
            {
                if (repeatMove) 
                    moved = 0;
                else 
                    moved = children.Count - 1;
            }
            Select(moved);
        }

        public void Decided()
        {
            children[SelectedIdx].DecidedAction?.Invoke();
        }

        public void Canceled()
        {
            children[SelectedIdx].CanceledAction?.Invoke();
        }

        private int DirToInt(Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:
                    return -1;
                case Direction.Right:
                    return 1;
                case Direction.Down:
                    return column;
                case Direction.Up:
                    return -column;
                default:
                    return 0;
            }
        }

        public void AddChild(MenuChild child)
        {
            children.Add(child);
        }

        public void InsertChild(int idx, MenuChild child)
        {
            children.Insert(idx, child);
            if(SelectedIdx >= idx) SelectedIdx++;
        }

        public void RemoveChild(int idx)
        {
            children.RemoveAt(idx);
            if (SelectedIdx >= idx) Select(idx);
        }
    }

    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
}
