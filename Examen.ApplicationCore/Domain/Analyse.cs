﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Analyse
    {
        public int AnalyseId { get; set; }
        public int DureeResultat { get; set; }
        public double PrixResultat { get; set; }
        public string TypeAnalyse { get; set; }
        public string ValeurAnalyse { get; set; }
        public float ValeurMaxNormale { get; set; }
        public float ValeurMinNormale { get; set; }

        public IList<Bilan> Bilans  { get; set; }

    }
}
