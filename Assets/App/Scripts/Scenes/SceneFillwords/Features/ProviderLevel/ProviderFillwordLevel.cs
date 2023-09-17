using System;
using App.Scripts.Scenes.SceneFillwords.Features.FillwordModels;
using App.Scripts.Scenes.SceneFillwords.Features.FillwordsData;
using UnityEngine;

namespace App.Scripts.Scenes.SceneFillwords.Features.ProviderLevel
{
  public class ProviderFillwordLevel : IProviderFillwordLevel
  {
    //напиши реализацию не меняя сигнатуру функции
    public GridFillWords LoadModel(int index)
    {
      FillwordLevelData levelData = GetValidLevelData(index, new FillWordsLevelParser());

      var gridFillWords = new GridFillWords(levelData.GridSize);
      int counter = 0;
      
      for (int i = 0; i < levelData.GridSize.x; i++)
      {
        for (int j = 0; j < levelData.GridSize.y; j++)
        {
          var letterIndex = levelData.GetLetterIndex(counter++);
          gridFillWords.Set(i, j, new CharGridModel(levelData.Letters[letterIndex]));
        }
      }

      return gridFillWords;
    }
    
    private FillwordLevelData GetValidLevelData(int index, FillWordsLevelParser levelParser)
    {
      index -= 1;
      
      for (int i = index; i < levelParser.LevelsCapacity; i++)
      {
        var levelData = levelParser.GetLevelData(i);
        
        if (levelData != null)
          return levelData;
      }
      
      throw new Exception();
    }
  }
}