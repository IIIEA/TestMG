using System;
using System.Collections.Generic;

namespace App.Scripts.Scenes.SceneChess.Features.ChessMovement
{
  public class King : Piece
  {
    private readonly List<Tuple<int, int>> _kingMoves = new()
    {
      Tuple.Create(0, 1),
      Tuple.Create(0, -1),
      Tuple.Create(1, 0),
      Tuple.Create(-1, 0),

      Tuple.Create(1, 1),
      Tuple.Create(-1, -1),
      Tuple.Create(1, -1),
      Tuple.Create(-1, 1)
    };

    protected override int Shift => 1;
    protected override List<Tuple<int, int>> DeltaMoves => _kingMoves;
  }
}