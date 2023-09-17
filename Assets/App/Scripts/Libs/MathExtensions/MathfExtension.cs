using UnityEngine;

namespace App.Scripts.Libs.MathExtensions
{
  public static class MathfExtension
  {
    public static bool HasSqrt(float number)
    {
      double num = Mathf.Sqrt(number);
      string[] array = num.ToString().Split(',');

      return array.Length == 1;
    }
  }
}