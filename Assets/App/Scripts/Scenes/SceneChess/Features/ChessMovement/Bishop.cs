using System;
using System.Collections.Generic;

namespace App.Scripts.Scenes.SceneChess.Features.ChessMovement
{
  public class Bishop : Piece
  {
    private readonly List<Tuple<int, int>> _bishopMoves = new()
    {
      Tuple.Create(1, 1),
      Tuple.Create(-1, -1),
      Tuple.Create(1, -1),
      Tuple.Create(-1, 1),
    };

    protected override int Shift => 8;
    protected override List<Tuple<int, int>> DeltaMoves => _bishopMoves;
  }
}