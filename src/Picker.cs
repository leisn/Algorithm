using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Leisn.Algorithm
{
    public class Picker
    {
        /// <summary>
        /// Pick in a row
        /// </summary>
        /// <param name="cells">Cells in a row, 1= to pick,0 = empty</param>
        /// <param name="pickers">Pickers, 0 = can pick,1 = full</param>
        /// <returns></returns>
        public static List<List<(int PickerIndex, int CellIndex)>> PickRow(int[] cells, int[] pickers)
        {
            var tempCells = new Span<int>(cells);
            var tempPickers = new Span<int>(pickers);
            var result = new List<List<(int, int)>>();
            int temp = 0;
            int cellIndex, pickerIndex;
            for (int i = 0; i < tempCells.Length; i++)
            {
                if (tempCells[i] == 0)
                    continue;
                for (int j = temp; j < tempPickers.Length; j++)
                {
                    if (tempPickers[j] == 1)
                        continue;
                    temp = j;
                    var length = Math.Min(tempCells.Length - i, tempPickers.Length - j);
                    var action = new List<(int Picker, int Cell)>();
                    for (int k = 0; k < length; k++)
                    {
                        cellIndex = k + i;
                        pickerIndex = k + j;
                        if (tempCells[cellIndex] == 1 && tempPickers[pickerIndex] == 0)
                        {
                            action.Add((pickerIndex, cellIndex));
                            tempCells[cellIndex] = 0;
                            tempPickers[pickerIndex] = 1;
                            if (pickerIndex - temp == 0)
                                temp = pickerIndex + 1;
                        }
                    }
                    Debug.Assert(action.Count > 0);
                    result.Add(action);
                    break;
                }
            }
            return result;
        }
    }
}
