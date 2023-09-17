using UnityEngine;

namespace App.Scripts.Infrastructure.AssetsProvider
{
  public static class AssetPath
  {
    public const string FillWordsLevels = "Fillwords/pack_0";
    public const string FillWordsList = "Fillwords/words_list";
    public const string SearchWordLevels = "WordSearch/Levels";
  }
}

public static class AssetProvider
{
  public static T GetAsset<T>(string path) where T : Object
  {
    var asset = Resources.Load<T>(path);
    return asset;
  }

  public static T[] GetAllAssets<T>(string path) where T : Object
  {
    var assets = Resources.LoadAll<T>(path);
    return assets;
  }
}