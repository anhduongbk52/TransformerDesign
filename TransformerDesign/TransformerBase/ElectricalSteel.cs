using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformerDesign.TransformerBase
{
    internal class ElectricalSteel
    {
        public ElectricalSteelType Type { get; set; }
        public string MaterialCode { get; set; }
        public double Thickness {  get; set; }
        public double Density {  get; set; }
        public double CoreLossNominal1750 {  get; set; }
        public double CoreLossMax1750 { get;set; }
        public double InductionMin { get; set;}
        public string Manufacturer {  get; set; }
        public string CountryOfOrigin { get; set; }
        public Dictionary<double, double> CoreLossNominal { get; set; }
        public double GetCoreLossNominal(double fluxDensity)
        {
            if (CoreLossNominal.ContainsKey(fluxDensity))
            return CoreLossNominal[fluxDensity];
            else
            {
                return 0;
            }
        }
    }

    public enum ElectricalSteelType
    {
        CRGO = 0,
        CRNGO=1,
        Amorphous=2
    }
}
