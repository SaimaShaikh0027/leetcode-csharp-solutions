public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> result = new List<IList<int>>();
        for(int i = 0; i < numRows; i++)
        {
            List<int> rows = new List<int>();
            for(int j = 0; j <= i; j++)
            {
                if(j == 0 || j == i)
                {
                    rows.Add(1);
                }
                else
                {
                    int value = result[i-1][j-1] + result[i-1][j];
                    rows.Add(value);
                }
            }
            result.Add(rows);
        }
        return result;
    }
}