﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace CanWeFixItService
{
    public interface IDatabaseService
    {
        Task<IEnumerable<Instrument>> InstrumentsAsync();
        Task<IEnumerable<MarketData>> MarketData();
        void SetupDatabase();
    }
}