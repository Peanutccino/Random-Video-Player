
namespace RandomVideoPlayerV3.Model
{
    static class RandomExtension
    {
        public static IEnumerable<T> Shuffle<T>(this Random rng, IEnumerable<T> input)
        {
            List<T> list = input.ToList(); 
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
    }
}
