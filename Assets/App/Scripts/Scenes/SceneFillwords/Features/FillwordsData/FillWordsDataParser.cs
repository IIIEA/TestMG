using System.Collections.Generic;
using System.Linq;
using App.Scripts.Infrastructure.AssetsProvider;
using UnityEngine;

namespace App.Scripts.Scenes.SceneFillwords.Features.FillwordsData
{
  public class FillWordsLevelParser
  {
    private static readonly char[] WORDS_SEPARATORS = new[] { ' ' };
    private static readonly char[] CHAR_INDEXES_SEPARATORS = new[] { ';' };

    private string[] _levelsData;
    private string[] _wordsData;

    public int LevelsCapacity => _levelsData.Length;

    public FillWordsLevelParser()
    {
      var levelDataFile = AssetProvider.GetAsset<TextAsset>(AssetPath.FillWordsLevels);
      var wordsDataFile = AssetProvider.GetAsset<TextAsset>(AssetPath.FillWordsList);

      _levelsData = levelDataFile.text.Split('\n');
      _levelsData = RemoveDuplicates(_levelsData);
      
      _wordsData = wordsDataFile.text.Split('\n');
    }

    public FillwordLevelData GetLevelData(int index)
    {
      string data = TryGetLevelData(index);

      if (data == null)
        return null;

      FillwordLevelData levelData = new FillwordLevelData();
      List<int> letterIndexes = new List<int>();

      string[] parts = _levelsData[index].Trim().Split(separator: WORDS_SEPARATORS);

      for (var i = 0; i < parts.Length; i += 2)
      {
        int wordIndex = int.Parse(parts[i]);

        string[] numbersStr = parts[i + 1].Split(separator: CHAR_INDEXES_SEPARATORS);
        letterIndexes = letterIndexes.Union(numbersStr.Select(int.Parse).ToList()).ToList();
        
        var wordData = TryGetWordData(wordIndex);
        levelData.AddWord(wordData);
      }
      
      levelData.SetCharIndexes(letterIndexes.ToArray());
      
      return levelData.IsLevelValid() ? levelData : null;
    }
    
    public static string[] RemoveDuplicates(string[] array) => 
      new HashSet<string>(array.ToList()).ToArray();

    private string TryGetLevelData(int levelIndex)
    {
      if (levelIndex > _levelsData.Length || levelIndex < 0)
        return null;

      return _levelsData[levelIndex];
    }

    private FillWordData TryGetWordData(int index)
    {
      if (index > _wordsData.Length)
        return null;

      FillWordData wordData = new FillWordData(_wordsData[index].Trim());

      return wordData;
    }
  }
}