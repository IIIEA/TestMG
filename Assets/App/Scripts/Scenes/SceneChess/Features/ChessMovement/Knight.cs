using System;
using System.Collections.Generic;

namespace App.Scripts.Scenes.SceneChess.Features.ChessMovement
{
  public class Knight : Piece
  {
    private readonly List<Tuple<int, int>> _knightMoves = new()
    {
      Tuple.Create(1, 2),
      Tuple.Create(-1, 2),
      Tuple.Create(1, -2),
      Tuple.Create(-1, -2),

      Tuple.Create(2, 1),
      Tuple.Create(-2, 1),
      Tuple.Create(2, -1),
      Tuple.Create(-2, -1)
    };

    protected override int Shift => 1;
    protected override List<Tuple<int, int>> DeltaMoves => _knightMoves;
  }
}