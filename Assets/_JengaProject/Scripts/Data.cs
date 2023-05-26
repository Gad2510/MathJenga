using System.Collections.Generic;
[System.Serializable]
public class Data
{
    public Entry[] lst_recordLst;

    public Entry[] FilterByGrade(int grade)
    {
        return lst_recordLst;
    }

    public void SortList()
    {

    }
}
