﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace CanWeFixItService
{
    public interface IDatabaseService
    {
        Task<IEnumerable<Instrument>> InstrumentsAsync();
        Task<IEnumerable<MarketData>> MarketDataAsync();
        Task<IEnumerable<MarketValuation>> ValuationsAsync();
        Task<IEnumerable<MarketData>> AllMarketDataAsync();
        void SetupDatabase();
    }
}