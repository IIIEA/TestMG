using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Scripts.Libs.MathExtensions;
using UnityEngine;

namespace App.Scripts.Scenes.SceneFillwords.Features.FillwordsData
{
  public class FillwordLevelData
  {
    private int[] _charIndexes; 
    private readonly List<FillWordData> _wordsData = new();
    
    public IReadOnlyCollection<FillWordData> WordsData => _wordsData.AsReadOnly();

    public char[] Letters
    {
      get
      {
        StringBuilder stringBuilder = new StringBuilder();
        
        _wordsData.ForEach(wordData => stringBuilder.Append(wordData.Word));

        return stringBuilder.ToString().Trim().ToCharArray();
      }
    }
    
    public Vector2Int GridSize
    {
      get
      {
        int gridSize = (int)Mathf.Sqrt(_charIndexes.Length);
        return new Vector2Int(gridSize, gridSize);
      }
    }

    public int GetLetterIndex(int index) => 
      _charIndexes[index];

    public void AddWord(FillWordData fillWordData) =>
      _wordsData.Add(fillWordData);

    public void SetCharIndexes(int[] indexes) => 
      _charIndexes = indexes;

    public bool IsLevelValid()
    {
      if (_charIndexes.Length != Letters.Length)
        return false;

      if (_charIndexes.ToList().Distinct().Skip(1).Any() == false)
        return false;

      if (MathfExtension.HasSqrt(_charIndexes.Length) == false)
        return false;

      if (_charIndexes.Max() > _charIndexes.Length)
        return false;

      return true;
    }
  }
}