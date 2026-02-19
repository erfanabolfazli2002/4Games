using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Scores
{
    int level;
    int sc;
    public Scores(int level, int sc)
    {
        this.level = level;
        this.sc = sc;
    }
    public int GetLevel => level;
    public int GetScore => sc;
}