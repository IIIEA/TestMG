using System;
using System.Collections.Generic;
using App.Scripts.Scenes.SceneChess.Features.ChessField.GridMatrix;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.ChessMovement
{
  public abstract class Piece
  {
    protected abstract int Shift { get; }
    protected abstract List<Tuple<int, int>> DeltaMoves { get; }

    public List<Vector2Int> GetPossibleMoves(Vector2Int currentPosition, ChessGrid grid)
    {
      List<Vector2Int> validMoves = new List<Vector2Int>();

      foreach (Tuple<int, int> moves in DeltaMoves)
      {
        int deltaRow = moves.Item1;
        int deltaCol = moves.Item2;

        for (int i = Shift; i > 0; i--)
        {
          if (IsValidMove(currentPosition, deltaRow * i, deltaCol * i, grid))
          {
            validMoves.Add(new Vector2Int(currentPosition.x + deltaRow * i, currentPosition.y + deltaCol * i));
          }
        }
      }

      return validMoves;
    }

    public bool IsValidMove(Vector2Int currentPosition, int rowMove, int colMove, ChessGrid grid)
    {
      var nextRowPosition = currentPosition.x + rowMove;
      var nextColPosition = currentPosition.y + colMove;

      bool legalRow = (nextRowPosition >= 0) && (nextRowPosition < grid.Size.x);
      bool legalCol = (nextColPosition >= 0) && (nextColPosition < grid.Size.y);

      return (legalCol && legalRow) && grid.Get(nextColPosition, nextRowPosition) == null;
    }
  }
}