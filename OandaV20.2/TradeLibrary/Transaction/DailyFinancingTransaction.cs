﻿using System.Collections.Generic;

namespace OkonkwoOandaV20.TradeLibrary.Transaction
{
   public class DailyFinancingTransaction : Transaction
   {
      public decimal financing { get; set; }
      public decimal accountBalance { get; set; }
      public string accountFinancingMode { get; set; }
      public PositionFinancing positionFinancing { get; set; }
   }
}
