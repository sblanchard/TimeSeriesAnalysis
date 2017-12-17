﻿using System;
using Common;

namespace TeslaAnalysis.Indicators
{
    public class TrueRange : Indicator
    {
        public TrueRange(Func<DateTime, double> function) : base(function)
        {
        }

        public static TrueRange Create(CandleTimeSeries series)
        {
            double Function(DateTime date)
            {
                Candle currentCandle = series[date];
                int index = series.GetIndex(currentCandle);
                Candle previousCandle = series[index - 1];

                double trueRange = Utils.Max(
                    currentCandle.Max - currentCandle.Min,
                    currentCandle.Max - previousCandle.Close,
                    currentCandle.Min - previousCandle.Close);

                return trueRange;
            }

            TrueRange ind = new TrueRange(Function);
            return ind;
        }
    }
}