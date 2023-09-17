using System.Collections.Generic;
using System.Linq;
using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.BuilderLevelModel
{
  public class FactoryLevelModel : IFactory<LevelModel, LevelInfo, int>
  {
    public LevelModel Create(LevelInfo value, int levelNumber)
    {
      var model = new LevelModel();

      model.LevelNumber = levelNumber;

      model.Words = value.words;
      model.InputChars = BuildListChars(value.words);

      return model;
    }

    private List<char> BuildListChars(List<string> words)
    {
      List<char> charsList = new List<char>();
      Dictionary<char, int> resultCharsDictionary = new Dictionary<char, int>();

      foreach (var word in words)
      {
        List<char> chars = word.ToCharArray().ToList();
        Dictionary<char, int> sameCharsCountDictionary = new Dictionary<char, int>();

        var groupedList = chars.GroupBy(letter => letter);

        foreach (var letter in groupedList)
          sameCharsCountDictionary.Add(letter.Key, letter.Count());

        resultCharsDictionary = resultCharsDictionary.Union(sameCharsCountDictionary)
          .ToLookup(pair => pair.Key, pair => pair.Value)
          .ToDictionary(group => group.Key, group => group.Max());
      }

      foreach (var result in resultCharsDictionary)
      {
        for (int i = 0; i < result.Value; i++)
        {
          charsList.Add(result.Key);
        }
      }

      return charsList;
    }
  }
}