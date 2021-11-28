using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisScoring;

public interface IScoreBoardScreenController
{
    void OnEnable();

    void PrintCurrentSetScore();
    void PrintGameCurrentScore();
}
