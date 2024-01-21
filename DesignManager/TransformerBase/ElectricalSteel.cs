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
        public double MaterialCode { get; set; }
        private double _Thickness;
        public double Thickness { get => _Thickness; set => _Thickness = value; }
        public double Density {  get; set; }
        private double _CoreLossNominal1750;
        public double CoreLossNominal1750 { get => _CoreLossNominal1750; set => _CoreLossNominal1750 = value; }

        private double _CoreLossMax1750;
        public double CoreLossMax1750 { get => _CoreLossMax1750; set => _CoreLossMax1750 = value; }
        private double _CoreLossNominal1550;
        public double CoreLossNominal1550 { get => _CoreLossNominal1550; set => _CoreLossNominal1550 = value; }
        private double _CoreLossMax1550;
        public double CoreLossMax1550 { get => _CoreLossMax1550; set => _CoreLossMax1550 = value; }
        public double InductionMin { get; set;}
        public string Manufacturer {  get; set; }
        public string CountryOfOrigin { get; set; }
        private Dictionary<double, double> _CoreLossNominal;
        public Dictionary<double, double> CoreLossNominal { get => _CoreLossNominal; set => _CoreLossNominal = value; }

        public ElectricalSteel()
        {
            CoreLossNominal = new  Dictionary<double, double>();
        }
        public double GetCoreLossNominal(double fluxDensity)
        {
            if (_CoreLossNominal.Count==0)
            {               
                if (_CoreLossNominal1750 != 0)
                {
                    _CoreLossNominal.Add(1.7, _CoreLossNominal1750);
                }
                if (_CoreLossNominal1550 != 0)
                {
                    _CoreLossNominal.Add(1.5, _CoreLossNominal1550);
                }
            }
            if (_CoreLossNominal.Count == 0)
            {
                throw new Exception("Không có dữ liệu về suất tổn hao của tôn silic.");
            }                
            else  if (_CoreLossNominal.ContainsKey(fluxDensity))  return _CoreLossNominal[fluxDensity];
            else
            {
                double referenceKey= FindClosestKey(_CoreLossNominal, fluxDensity);
                double referenceValue = _CoreLossNominal[referenceKey];
                return referenceValue*(fluxDensity/referenceKey)*(fluxDensity / referenceKey);
            }
        }
        public static double FindClosestKey(Dictionary<double, double> dictionary, double targetValue)
        {
            // Sắp xếp các key theo khoảng cách tới targetValue
            var sortedKeys = dictionary.Keys.OrderBy(key => Math.Abs(key - targetValue));

            // Lấy key đầu tiên (gần nhất)
            double closestKey = sortedKeys.First();
            return closestKey;
        }
    }

    public enum ElectricalSteelType
    {
        CRGO = 0,
        CRNGO=1,
        Amorphous=2
    }
    
}
