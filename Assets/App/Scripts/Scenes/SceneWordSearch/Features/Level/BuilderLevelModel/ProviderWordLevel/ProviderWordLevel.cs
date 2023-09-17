using System;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.SearchWordData;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.BuilderLevelModel.ProviderWordLevel
{
  public class ProviderWordLevel : IProviderWordLevel
  {
    public LevelInfo LoadLevelData(int levelIndex)
    {
      SearchWordDataParser dataParser = new SearchWordDataParser();
      
      LevelInfo levelInfo = dataParser.GetWordsList(levelIndex);

      return levelInfo ?? throw new Exception();
    }
  }
}