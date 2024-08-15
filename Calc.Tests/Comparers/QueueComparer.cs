namespace Calc.Tests.Comparers
{
  public class QueueComparer<T> : IEqualityComparer<Queue<T>>
  {
    private readonly IEqualityComparer<T> _comparer;

    public QueueComparer(IEqualityComparer<T>? comparer = null)
    {
      _comparer = comparer ?? EqualityComparer<T>.Default;
    }

    public bool Equals(Queue<T>? x, Queue<T>? y)
    {
      if (x == null && y == null)
        return true;

      if (x == null || y == null)
        return false;

      if (x.Count != y.Count)
        return false;

      var arrayX = x.ToArray();
      var arrayY = y.ToArray();

      for (var i = 0; i < arrayX.Length; i++)
      {
        if (!_comparer.Equals(arrayX[i], arrayY[i]))
          return false;
      }

      return true;
    }

    public int GetHashCode(Queue<T> obj)
    {
      if (obj == null)
        return 0;

      int hash = 17;

      foreach (var item in obj)
      {
        hash = 31 * hash + _comparer.GetHashCode(item!);
      }

      return hash;
    }
  }
}
