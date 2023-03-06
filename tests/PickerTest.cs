using Leisn.Algorithm;

namespace Tests
{
    [TestClass]
    public class PickerTest
    {
        [TestMethod]
        [DataRow("111111100", "0000000", "[(0,0),(1,1),(2,2),(3,3),(4,4),(5,5),(6,6)]")]
        [DataRow("111111100", "0101010", "[(0,0),(2,2),(4,4),(6,6)]")]
        [DataRow("00111111100", "0000000", "[(0,2),(1,3),(2,4),(3,5),(4,6),(5,7),(6,8)]")]
        [DataRow("1010101010101010", "0000000", "[(0,0),(2,2),(4,4),(6,6)],[(1,8),(3,10),(5,12)]")]
        [DataRow("0111010111010", "0000000", "[(0,1),(1,2),(2,3),(4,5),(6,7)],[(3,8)],[(5,9)]")]
        public void TestPickRow(string cells, string pickers, string result)
        {
            var re1 = Picker.PickRow(FromString(cells), FromString(pickers));
            var resultString = "";
            var count = re1.Count;
            for (int i = 0; i < count; i++)
            {
                var step = re1[i];

                for (int j = 0; j < step.Count; j++)
                {
                    var (PickerIndex, CellIndex) = step[j];
                    if (j == 0)
                        resultString += "[";
                    resultString += $"({PickerIndex},{CellIndex})";
                    if (j == step.Count - 1)
                        resultString += "]";
                    else
                        resultString += ",";
                }
                if (i != count - 1)
                    resultString += ",";
            }
            Assert.AreEqual(result, resultString);
        }

        private static int[] FromString(string str)
        {
            var result = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                result[i] = int.Parse(str.Substring(i, 1));
            }
            return result;
        }

    }
}
