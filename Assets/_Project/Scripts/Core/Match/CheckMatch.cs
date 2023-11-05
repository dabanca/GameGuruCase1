using System.Collections.Generic;
using _Project.Scripts.Core.Collections;
using _Project.Scripts.Core.Grid;

namespace _Project.Scripts.Core.Match
{
    public class CheckMatch
    {
        private readonly HashSet<GridCell> _matchCells;
        public CheckMatch()
        {
            _matchCells = new HashSet<GridCell>();
        }
        
        public void SearchForMatch(GridCell cell)
        {
            _matchCells.Clear();
            
            Queue<GridCell> searchQueue = new Queue<GridCell>();
            HashSet<GridCell> searchedCells = new HashSet<GridCell>();
            searchedCells.Add(cell);

            FirstSearch(cell, searchQueue);

            while (searchQueue.Count > 0)
            {
                var tempCell = searchQueue.Dequeue();
                searchedCells.Add(tempCell);
                _matchCells.Add(tempCell);
                Search(tempCell, searchedCells, searchQueue);
            }

            if (_matchCells.Count > 0) _matchCells.Add(cell);

            if (_matchCells.Count <= 2) return;
            foreach (var item in _matchCells)
                item.Match();
        }

        private void Search(GridCell searchCell, HashSet<GridCell> searchedCells, Queue<GridCell> searchQueue)
        {
            if (searchCell.IsMatched(Directions.Top) && !searchedCells.Contains(searchCell.GetNeighbour(Directions.Top)))
                searchQueue.Enqueue(searchCell.GetNeighbour(Directions.Top));
        
            if (searchCell.IsMatched(Directions.Right) && !searchedCells.Contains(searchCell.GetNeighbour(Directions.Right)))
                searchQueue.Enqueue(searchCell.GetNeighbour(Directions.Right));
        
            if (searchCell.IsMatched(Directions.Bottom) && !searchedCells.Contains(searchCell.GetNeighbour(Directions.Bottom)))
                searchQueue.Enqueue(searchCell.GetNeighbour(Directions.Bottom));
        
            if (searchCell.IsMatched(Directions.Left) && !searchedCells.Contains(searchCell.GetNeighbour(Directions.Left)))
                searchQueue.Enqueue(searchCell.GetNeighbour(Directions.Left));
        }

        private void FirstSearch(GridCell searchCell, Queue<GridCell> searchQueue)
        {
            if (searchCell.IsMatched(Directions.Top))
                searchQueue.Enqueue(searchCell.GetNeighbour(Directions.Top));
        
            if (searchCell.IsMatched(Directions.Right))
                searchQueue.Enqueue(searchCell.GetNeighbour(Directions.Right));
        
            if (searchCell.IsMatched(Directions.Bottom))
                searchQueue.Enqueue(searchCell.GetNeighbour(Directions.Bottom));
        
            if (searchCell.IsMatched(Directions.Left))
                searchQueue.Enqueue(searchCell.GetNeighbour(Directions.Left));
        }
    }
}