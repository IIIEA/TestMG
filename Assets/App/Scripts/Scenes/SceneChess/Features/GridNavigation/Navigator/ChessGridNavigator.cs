using System;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Scenes.SceneChess.Features.ChessField.GridMatrix;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using App.Scripts.Scenes.SceneChess.Features.ChessMovement;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator
{
  public class ChessGridNavigator : IChessGridNavigator
  {
    public List<Vector2Int> FindPath(ChessUnitType unit, Vector2Int from, Vector2Int to, ChessGrid grid)
    {
      Piece piece = GetPiece(unit);
      Queue<List<Vector2Int>> queue = new Queue<List<Vector2Int>>();
      List<Vector2Int> visited = new List<Vector2Int>();
      List<Vector2Int> path = new List<Vector2Int>();
      
      path.Add(from);
      queue.Enqueue(path);
      visited.Add(from);

      while (queue.Count != 0)
      {
        List<Vector2Int> currentPath = queue.Dequeue();
        Vector2Int currentPosition = currentPath.Last();

        if ((currentPosition.x == to.x) && (currentPosition.y == to.y))
        {
          currentPath.RemoveAt(0);
          return currentPath;
        }

        foreach (Vector2Int validMove in piece.GetPossibleMoves(currentPosition, grid))
        {
          if (!visited.Any(position => (position.x == validMove.x && position.y == validMove.y)))
          {
            List<Vector2Int> branch = new List<Vector2Int>();
            
            branch.AddRange(currentPath);
            branch.Add(validMove);

            visited.Add(validMove);

            queue.Enqueue(branch);
          }
        }
      }

      return null;
    }

    private Piece GetPiece(ChessUnitType type)
    {
      return type switch
      {
        ChessUnitType.Pon => new Pon(),
        ChessUnitType.King => new King(),
        ChessUnitType.Queen => new Queen(),
        ChessUnitType.Rook => new Rook(),
        ChessUnitType.Knight => new Knight(),
        ChessUnitType.Bishop => new Bishop(),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
      };
    }
  }
}