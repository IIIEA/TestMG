using App.Scripts.Infrastructure.AssetsProvider;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;
using UnityEngine;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.SearchWordData
{
  public class SearchWordDataParser
  {
    private TextAsset[] _levelsData;
    
    public SearchWordDataParser() => 
      _levelsData = AssetProvider.GetAllAssets<TextAsset>(AssetPath.SearchWordLevels);

    public LevelInfo GetWordsList(int levelIndex)
    {
      levelIndex -= 1;

      if (levelIndex < 0 || levelIndex > _levelsData.Length)
        return null;
      
      LevelInfo levelInfo = JsonUtility.FromJson<LevelInfo>(_levelsData[levelIndex].text);
      
      return levelInfo;
    }
  }
}