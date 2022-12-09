using System.Collections.Generic;
using IBApi;

namespace FishingSizes
{ 
    public class OrderSamples
    {
        public static Order AtAuction(string action, double quantity, double price)
        {
            //! [auction]
            Order order = new Order();
            order.Action = action;
            order.Tif = "AUC";
            order.OrderType = "MTL";
            order.TotalQuantity = quantity;
            order.LmtPrice = price;
            //! [auction]
            return order;
        }

        public static Order Discretionary(string action, double quantity, double price, double discretionaryAmount)
        {
            //! [discretionary]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LMT";
            order.TotalQuantity = quantity;
            order.LmtPrice = price;
            order.DiscretionaryAmt = discretionaryAmount;
            //! [discretionary]
            return order;
        }
        
        public static Order MarketOrder(string action, double quantity)
        {
            //! [market]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "MKT";
            order.TotalQuantity = quantity;
            //! [market]
            return order;
        }

        public static Order MarketIfTouched(string action, double quantity, double price)
        {
            //! [market_if_touched]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "MIT";
            order.TotalQuantity = quantity;
            order.AuxPrice = price;
            //! [market_if_touched]
            return order;
        }

        public static Order MarketOnClose(string action, double quantity)
        {
            //! [market_on_close]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "MOC";
            order.TotalQuantity = quantity;
            //! [market_on_close]
            return order;
        }

        public static Order MarketOnOpen(string action, double quantity)
        {
            //! [market_on_open]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "MKT";
            order.TotalQuantity = quantity;
            order.Tif = "OPG";
            //! [market_on_open]
            return order;
        }

        public static Order MidpointMatch(string action, double quantity)
        {
            //! [midpoint_match]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "MKT";
            order.TotalQuantity = quantity;
            //! [midpoint_match]
            return order;
        }

        public static Order Midprice(string action, double quantity, double priceCap)
        {
            //! [midprice]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "MIDPRICE";
            order.TotalQuantity = quantity;
			order.LmtPrice = priceCap;
            //! [midprice]
            return order;
        }
		
        public static Order PeggedToMarket(string action, double quantity, double marketOffset)
        {
            //! [pegged_market]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "PEG MKT";
            order.TotalQuantity = 100;
            order.AuxPrice = marketOffset;//Offset price
            //! [pegged_market]
            return order;
        }

        public static Order PeggedToStock(string action, double quantity, double delta, double stockReferencePrice, double startingPrice)
        {
            //! [pegged_stock]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "PEG STK";
            order.TotalQuantity = quantity;
            order.Delta = delta;
            order.StockRefPrice = stockReferencePrice;
            order.StartingPrice = startingPrice;
            //! [pegged_stock]
            return order;
        }

        public static Order RelativePeggedToPrimary(string action, double quantity, double priceCap, double offsetAmount)
        {
            //! [relative_pegged_primary]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "REL";
            order.TotalQuantity = quantity;
            order.LmtPrice = priceCap;
            order.AuxPrice = offsetAmount;
            //! [relative_pegged_primary]
            return order;
        }

        public static Order SweepToFill(string action, double quantity, double price)
        {
            //! [sweep_to_fill]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LMT";
            order.TotalQuantity = quantity;
            order.LmtPrice = price;
            order.SweepToFill = true;
            //! [sweep_to_fill]
            return order;
        }

        public static Order AuctionLimit(string action, double quantity, double price, int auctionStrategy)
        {
            //! [auction_limit]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LMT";
            order.TotalQuantity = quantity;
            order.LmtPrice = price;
            order.AuctionStrategy = auctionStrategy;
            //! [auction_limit]
            return order;
        }

        public static Order AuctionPeggedToStock(string action, double quantity, double startingPrice, double delta)
        {
            //! [auction_pegged_stock]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "PEG STK";
            order.TotalQuantity = quantity;
            order.Delta = delta;
            order.StartingPrice = startingPrice;
            //! [auction_pegged_stock]
            return order;
        }

        public static Order AuctionRelative(string action, double quantity, double offset)
        {
            //! [auction_relative]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "REL";
            order.TotalQuantity = quantity;
            order.AuxPrice = offset;
            //! [auction_relative]
            return order;
        }

        public static Order Block(string action, double quantity, double price)
        {
            // ! [block]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LMT";
            order.TotalQuantity = quantity;//Large volumes!
            order.LmtPrice = price;
            order.BlockOrder = true;
            // ! [block]
            return order;
        }

        public static Order BoxTop(string action, double quantity)
        {
            // ! [boxtop]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "BOX TOP";
            order.TotalQuantity = quantity;
            // ! [boxtop]
            return order;
        }

        public static Order LimitOrder(string action, double quantity, double limitPrice)
        {
            // ! [limitorder]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LMT";
            order.TotalQuantity = quantity;
            order.LmtPrice = limitPrice;
            // ! [limitorder]
            return order;
        }

        public static Order LimitOrderWithCashQty(string action, double quantity, double limitPrice, double cashQty)
        {
            // ! [limitorderwithcashqty]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LMT";
            order.TotalQuantity = quantity;
            order.LmtPrice = limitPrice;
            order.CashQty = cashQty;
            // ! [limitorderwithcashqty]
            return order;
        }

        public static Order LimitIfTouched(string action, double quantity, double limitPrice, double triggerPrice)
        {
            // ! [limitiftouched]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LIT";
            order.TotalQuantity = quantity;
            order.LmtPrice = limitPrice;
            order.AuxPrice = triggerPrice;
            // ! [limitiftouched]
            return order;
        }

        public static Order LimitOnClose(string action, double quantity, double limitPrice)
        {
            // ! [limitonclose]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LOC";
            order.TotalQuantity = quantity;
            order.LmtPrice = limitPrice;
            // ! [limitonclose]
            return order;
        }

        public static Order LimitOnOpen(string action, double quantity, double limitPrice)
        {
            // ! [limitonopen]
            Order order = new Order();
            order.Action = action;
            order.Tif = "OPG";
            order.OrderType = "LMT";
            order.TotalQuantity = quantity;
            order.LmtPrice = limitPrice;
            // ! [limitonopen]
            return order;
        }

        public static Order PassiveRelative(string action, double quantity, double offset)
        {
            // ! [passive_relative]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "PASSV REL";
            order.TotalQuantity = quantity;
            order.AuxPrice = offset;
            // ! [passive_relative]
            return order;
        }

        public static Order PeggedToMidpoint(string action, double quantity, double offset, double limitPrice)
        {
            // ! [pegged_midpoint]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "PEG MID";
            order.TotalQuantity = quantity;
            order.AuxPrice = offset;
			order.LmtPrice = limitPrice;
            // ! [pegged_midpoint]
            return order;
        }

        //! [bracket]
        public static List<Order> BracketOrder(int parentOrderId, string action, double quantity, double limitPrice, 
            double takeProfitLimitPrice, double stopLossPrice)
        {
            //This will be our main or "parent" order
            Order parent = new Order();
            parent.OrderId = parentOrderId;
            parent.Action = action;
            parent.OrderType = "LMT";
            parent.TotalQuantity = quantity;
            parent.LmtPrice = limitPrice;
            //The parent and children orders will need this attribute set to false to prevent accidental executions.
            //The LAST CHILD will have it set to true, 
            parent.Transmit = false;

            Order takeProfit = new Order();
            takeProfit.OrderId = parent.OrderId + 1;
            takeProfit.Action = action.Equals("BUY") ? "SELL" : "BUY";
            takeProfit.OrderType = "LMT";
            takeProfit.TotalQuantity = quantity;
            takeProfit.LmtPrice = takeProfitLimitPrice;
            takeProfit.ParentId = parentOrderId;
            takeProfit.Transmit = false;

            Order stopLoss = new Order();
            stopLoss.OrderId = parent.OrderId + 2;
            stopLoss.Action = action.Equals("BUY") ? "SELL" : "BUY";
            stopLoss.OrderType = "STP";
            //Stop trigger price
            stopLoss.AuxPrice = stopLossPrice;
            stopLoss.TotalQuantity = quantity;
            stopLoss.ParentId = parentOrderId;
            //In this case, the low side order will be the last child being sent. Therefore, it needs to set this attribute to true 
            //to activate all its predecessors
            stopLoss.Transmit = true;

            List<Order> bracketOrder = new List<Order>();
            bracketOrder.Add(parent);
            bracketOrder.Add(takeProfit);
            bracketOrder.Add(stopLoss);
            return bracketOrder;
        }
        //! [bracket]

        public static Order MarketToLimit(string action, double quantity)
        {
            // ! [markettolimit]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "MTL";
            order.TotalQuantity = quantity;
            // ! [markettolimit]
            return order;
        }

        public static Order MarketWithProtection(string action, double quantity)
        {
            // ! [marketwithprotection]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "MKT PRT";
            order.TotalQuantity = quantity;
            // ! [marketwithprotection]
            return order;
        }

        public static Order Stop(string action, double quantity, double stopPrice)
        {
            // ! [stop]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "STP";
            order.AuxPrice = stopPrice;
            order.TotalQuantity = quantity;
            // ! [stop]
            return order;
        }

        public static Order StopLimit(string action, double quantity, double limitPrice, double stopPrice)
        {
            // ! [stoplimit]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "STP LMT";
            order.TotalQuantity = quantity;
            order.LmtPrice = limitPrice;
            order.AuxPrice = stopPrice;
            // ! [stoplimit]
            return order;
        }

        public static Order StopWithProtection(string action, double quantity, double stopPrice)
        {
            // ! [stopwithprotection]
            Order order = new Order();
            order.TotalQuantity = quantity;
            order.Action = action;
            order.OrderType = "STP PRT";
            order.AuxPrice = stopPrice;
            // ! [stopwithprotection]
            return order;
        }

        public static Order TrailingStop(string action, double quantity, double trailingPercent, double trailStopPrice)
        {
            // ! [trailingstop]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "TRAIL";
            order.TotalQuantity = quantity;
            order.TrailingPercent = trailingPercent;
            order.TrailStopPrice = trailStopPrice;
            // ! [trailingstop]
            return order;
        }

        public static Order TrailingStopLimit(string action, double quantity, double lmtPriceOffset, double trailingAmount, double trailStopPrice)
        {
            // ! [trailingstoplimit]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "TRAIL LIMIT";
            order.TotalQuantity = quantity;
            order.TrailStopPrice = trailStopPrice;
            order.LmtPriceOffset = lmtPriceOffset;
            order.AuxPrice = trailingAmount;
            // ! [trailingstoplimit]
            return order;
        }

        public static Order ComboLimitOrder(string action, double quantity, double limitPrice, bool nonGuaranteed)
        {
            // ! [combolimit]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LMT";
            order.TotalQuantity = quantity;
            order.LmtPrice = limitPrice;
            if (nonGuaranteed)
            {
                order.SmartComboRoutingParams = new List<TagValue>();
                order.SmartComboRoutingParams.Add(new TagValue("NonGuaranteed", "1"));
            }
            // ! [combolimit]
            return order;
        }

        public static Order ComboMarketOrder(string action, double quantity, bool nonGuaranteed)
        {
            // ! [combomarket]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "MKT";
            order.TotalQuantity = quantity;
            if (nonGuaranteed)
            {
                order.SmartComboRoutingParams = new List<TagValue>();
                order.SmartComboRoutingParams.Add(new TagValue("NonGuaranteed", "1"));
            }
            // ! [combomarket]
            return order;
        }

        public static Order LimitOrderForComboWithLegPrices(string action, double quantity, double[] legPrices, bool nonGuaranteed)
        {
            // ! [limitordercombolegprices]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LMT";
            order.TotalQuantity = quantity;
            order.OrderComboLegs = new List<OrderComboLeg>();
            foreach(double price in legPrices)
            {
                OrderComboLeg comboLeg = new OrderComboLeg();
                comboLeg.Price = 5.0;
                order.OrderComboLegs.Add(comboLeg);
            }           
            if (nonGuaranteed)
            {
                order.SmartComboRoutingParams = new List<TagValue>();
                order.SmartComboRoutingParams.Add(new TagValue("NonGuaranteed", "1"));
            }
            // ! [limitordercombolegprices]
            return order;
        }

        public static Order RelativeLimitCombo(string action, double quantity, double limitPrice, bool nonGuaranteed)
        {
            // ! [relativelimitcombo]
            Order order = new Order();
            order.Action = action;
            order.TotalQuantity = quantity;
            order.OrderType = "REL + LMT";
            order.LmtPrice = limitPrice;
            if (nonGuaranteed)
            {
                order.SmartComboRoutingParams = new List<TagValue>();
                order.SmartComboRoutingParams.Add(new TagValue("NonGuaranteed", "1"));
            }
            // ! [relativelimitcombo]
            return order;
        }

        public static Order RelativeMarketCombo(string action, double quantity, bool nonGuaranteed)
        {
            // ! [relativemarketcombo]
            Order order = new Order();
            order.Action = action;
            order.TotalQuantity = quantity;
            order.OrderType = "REL + MKT";
            if (nonGuaranteed)
            {
                order.SmartComboRoutingParams = new List<TagValue>();
                order.SmartComboRoutingParams.Add(new TagValue("NonGuaranteed", "1"));
            }
            // ! [relativemarketcombo]
            return order;
        }

       // ! [oca]
        public static List<Order> OneCancelsAll(string ocaGroup, List<Order> ocaOrders, int ocaType)
        {
            foreach (Order o in ocaOrders)
            {
                o.OcaGroup = ocaGroup;
                o.OcaType = ocaType;
            }
            return ocaOrders;
        }
        // ! [oca]

        public static Order Volatility(string action, double quantity, double volatilityPercent, int volatilityType)
        {
            // ! [volatility]
            Order order = new Order();
            order.Action = action;
            order.OrderType = "VOL";
            order.TotalQuantity = quantity;
            order.Volatility = volatilityPercent;//Expressed in percentage (40%)
            order.VolatilityType = volatilityType;// 1=daily, 2=annual
            // ! [volatility]
            return order;
        }

        //! [fhedge]
        public static Order MarketFHedge(int parentOrderId, string action)
        {
            //FX Hedge orders can only have a quantity of 0
            Order order = MarketOrder(action, 0);
            order.ParentId = parentOrderId;
            order.HedgeType = "F";
            return order;
        }
        //! [fhedge]

        public static Order PeggedToBenchmark(string action, double quantity, double startingPrice, bool peggedChangeAmountDecrease, double peggedChangeAmount,
             double referenceChangeAmount, int referenceConId, string referenceExchange, double stockReferencePrice,  
            double referenceContractLowerRange, double referenceContractUpperRange)
        {
            //! [pegged_benchmark]
            Order order = new Order();
            order.OrderType = "PEG BENCH";
            //BUY or SELL
            order.Action = action;
            order.TotalQuantity = quantity;
            //Beginning with price...
            order.StartingPrice = startingPrice;
            //increase/decrease price..
            order.IsPeggedChangeAmountDecrease = peggedChangeAmountDecrease;
            //by... (and likewise for price moving in opposite direction)
            order.PeggedChangeAmount = peggedChangeAmount;
            //whenever there is a price change of...
            order.ReferenceChangeAmount = referenceChangeAmount;
            //in the reference contract...
            order.ReferenceContractId = referenceConId;
            //being traded at...
            order.ReferenceExchange = referenceExchange;
            //starting reference price is...
            order.StockRefPrice = stockReferencePrice;
            //Keep order active as long as reference contract trades between...
            order.StockRangeLower = referenceContractLowerRange;
            //and...
            order.StockRangeUpper = referenceContractUpperRange;
            //! [pegged_benchmark]
            return order;
        }
        

        public static Order AttachAdjustableToStop(Order parent, double attachedOrderStopPrice, double triggerPrice, double adjustStopPrice)
        {
            //! [adjustable_stop]
            //Attached order is a conventional STP order in opposite direction
            Order order = Stop(parent.Action.Equals("BUY") ? "SELL" : "BUY", parent.TotalQuantity, attachedOrderStopPrice);
            order.ParentId = parent.OrderId;
            //When trigger price is penetrated
            order.TriggerPrice = triggerPrice;
            //The parent order will be turned into a STP order
            order.AdjustedOrderType = "STP";
            //With the given STP price
            order.AdjustedStopPrice = adjustStopPrice;
            //! [adjustable_stop]
            return order;
        }

        public static Order AttachAdjustableToStopLimit(Order parent, double attachedOrderStopPrice, double triggerPrice, 
            double adjustedStopPrice, double adjustedStopLimitPrice)
        {
            //! [adjustable_stop_limit]
            //Attached order is a conventional STP order
            Order order = Stop(parent.Action.Equals("BUY") ? "SELL" : "BUY", parent.TotalQuantity, attachedOrderStopPrice);
            order.ParentId = parent.OrderId;
            //When trigger price is penetrated
            order.TriggerPrice = triggerPrice;
            //The parent order will be turned into a STP LMT order
            order.AdjustedOrderType = "STP LMT";
            //With the given stop price
            order.AdjustedStopPrice = adjustedStopPrice;
            //And the given limit price
            order.AdjustedStopLimitPrice = adjustedStopLimitPrice;
            //! [adjustable_stop_limit]
            return order;
        }
		
		public static Order AttachAdjustableToTrail(Order parent, double attachedOrderStopPrice, double triggerPrice, double adjustedStopPrice, 
            double adjustedTrailAmount, int trailUnit)
        {
            //! [adjustable_trail]
            //Attached order is a conventional STP order
            Order order = Stop(parent.Action.Equals("BUY") ? "SELL" : "BUY", parent.TotalQuantity, attachedOrderStopPrice);
            order.ParentId = parent.OrderId;
            //When trigger price is penetrated
            order.TriggerPrice = triggerPrice;
            //The parent order will be turned into a TRAIL order
            order.AdjustedOrderType = "TRAIL";
            //With a stop price of...
            order.AdjustedStopPrice = adjustedStopPrice;
            //traling by and amount (0) or a percent (1)...
            order.AdjustableTrailingUnit = trailUnit;
            //of...
            order.AdjustedTrailingAmount = adjustedTrailAmount;
            //! [adjustable_trail]        
            return order;
        }

        public static Order WhatIfLimitOrder(string action, double quantity, double limitPrice)
        {
            // ! [whatiflimitorder]
            Order order = LimitOrder(action, quantity, limitPrice);
            order.WhatIf = true;
            // ! [whatiflimitorder]
            return order;
        }

        public static PriceCondition PriceCondition(int conId, string exchange, double price, bool isMore, bool isConjunction)
        {
            //! [price_condition]
            //Conditions have to be created via the OrderCondition.Create 
            PriceCondition priceCondition = (PriceCondition)OrderCondition.Create(OrderConditionType.Price);
            //When this contract...
            priceCondition.ConId = conId;
            //traded on this exchange
            priceCondition.Exchange = exchange;
            //has a price above/below
            priceCondition.IsMore = isMore;
            //this quantity
            priceCondition.Price = price;
            //AND | OR next condition (will be ignored if no more conditions are added)
            priceCondition.IsConjunctionConnection = isConjunction;
            //! [price_condition]
            return priceCondition;
        }

        public static ExecutionCondition ExecutionCondition(string symbol, string secType, string exchange, bool isConjunction)
        {
            //! [execution_condition]
            ExecutionCondition execCondition = (ExecutionCondition)OrderCondition.Create(OrderConditionType.Execution);
            //When an execution on symbol
            execCondition.Symbol = symbol;
            //at exchange
            execCondition.Exchange = exchange;
            //for this secType
            execCondition.SecType = secType;
            //AND | OR next condition (will be ignored if no more conditions are added)
            execCondition.IsConjunctionConnection = isConjunction;
            //! [execution_condition]
            return execCondition;
        }

        public static MarginCondition MarginCondition(int percent, bool isMore, bool isConjunction)
        {
            //! [margin_condition]
            MarginCondition marginCondition = (MarginCondition)OrderCondition.Create(OrderConditionType.Margin);
            //If margin is above/below
            marginCondition.IsMore = isMore;
            //given percent
            marginCondition.Percent = percent;
            //AND | OR next condition (will be ignored if no more conditions are added)
            marginCondition.IsConjunctionConnection = isConjunction;
            //! [margin_condition]
            return marginCondition;
        }

        public static PercentChangeCondition PercentageChangeCondition(double pctChange, int conId, string exchange, bool isMore, bool isConjunction)
        {
            //! [percentage_condition]
            PercentChangeCondition pctChangeCondition = (PercentChangeCondition)OrderCondition.Create(OrderConditionType.PercentCange);
            //If there is a price percent change measured against last close price above or below...
            pctChangeCondition.IsMore = isMore;
            //this amount...
            pctChangeCondition.ChangePercent = pctChange;
            //on this contract
            pctChangeCondition.ConId = conId;
            //when traded on this exchange...
            pctChangeCondition.Exchange = exchange;
            //AND | OR next condition (will be ignored if no more conditions are added)
            pctChangeCondition.IsConjunctionConnection = isConjunction;
            //! [percentage_condition]
            return pctChangeCondition;
        }

        public static TimeCondition TimeCondition(string time, bool isMore, bool isConjunction)
        {
            //! [time_condition]
            TimeCondition timeCondition = (TimeCondition)OrderCondition.Create(OrderConditionType.Time);
            //Before or after...
            timeCondition.IsMore = isMore;
            //this time..
            timeCondition.Time = time;
            //AND | OR next condition (will be ignored if no more conditions are added)     
            timeCondition.IsConjunctionConnection = isConjunction;
            //! [time_condition]
            return timeCondition;
        }

        public static VolumeCondition VolumeCondition(int conId, string exchange, bool isMore, int volume, bool isConjunction)
        {
            //! [volume_condition]
            VolumeCondition volCond = (VolumeCondition)OrderCondition.Create(OrderConditionType.Volume);
            //Whenever contract...
            volCond.ConId = conId;
            //When traded at
            volCond.Exchange = exchange;
            //reaches a volume higher/lower
            volCond.IsMore = isMore;
            //than this...
            volCond.Volume = volume;
            //AND | OR next condition (will be ignored if no more conditions are added)
            volCond.IsConjunctionConnection = isConjunction;
            //! [volume_condition]
            return volCond;

        }

    }
}
