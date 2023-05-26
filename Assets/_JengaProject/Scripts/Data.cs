using System.Linq;
using UnityEngine;
[System.Serializable]
public class Data
{
    public Entry[] lst_recordLst;

    public Entry[] FilterByGrade(int grade)
    {
        string filter = $"{grade}th Grade";
        Entry[] result = null;
        if (lst_recordLst.Any(x => x.grade == filter))
            result = lst_recordLst.Where(x => x.grade == filter).ToArray();
        return result;
    }

    public void SortList()
    {
        lst_recordLst=lst_recordLst.OrderBy(x => x.domain).ThenBy(x=>x.cluster).ThenBy(x=>x.standardid).ToArray();
    }
}
