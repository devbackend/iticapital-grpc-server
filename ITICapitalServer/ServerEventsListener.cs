using System;
using System.Text.Json;
using Confluent.Kafka;
using ITICapitalServer.Events;
using ITICapitalServer.Logging;
using SmartCOM4Lib;

namespace ITICapitalServer
{
    public class ServerEventsListener
    {
        private readonly StServerClass _smartCom;
        private readonly IProducer<Null, string> _producer;
        private readonly ILogger _logger;

        public ServerEventsListener(StServerClass server, IProducer<Null, string> kafkaProducer, ILogger logger)
        {
            _smartCom = server;
            _producer = kafkaProducer;
            _logger = logger;
        }

        public void Start()
        {
            _smartCom.Connected += OnConnected;
            _smartCom.Disconnected += OnDisconnected;

            _smartCom.AddBar += OnAddBar;
            _smartCom.AddPortfolio += OnAddPortfolio;
            _smartCom.AddSymbol += OnAddSymbol;
            _smartCom.AddTick += OnAddTick;
            _smartCom.AddTickHistory += OnAddTickHistory;
            _smartCom.AddTrade += OnAddTrade;
            _smartCom.OrderCancelFailed += OnOrderCancelFailed;
            _smartCom.OrderCancelSucceeded += OnOrderCancelSucceeded;
            _smartCom.OrderMoveFailed += OnOrderMoveFailed;
            _smartCom.OrderMoveSucceeded += OnOrderMoveSucceeded;
            _smartCom.OrderFailed += OnOrderFailed;
            _smartCom.OrderSucceeded += OnOrderSucceeded;
            _smartCom.SetMyClosePos += OnSetMyClosePos;
            _smartCom.SetMyOrder += OnSetMyOrder;
            _smartCom.SetMyTrade += OnSetMyTrade;
            _smartCom.SetPortfolio += OnSetPortfolio;
            _smartCom.UpdateBidAsk += OnUpdateBidAsk;
            _smartCom.UpdatePosition += OnUpdatePosition;
            _smartCom.UpdateOrder += OnUpdateOrder;
            _smartCom.UpdateQuote += OnUpdateQuote;
        }

        private void OnUpdateQuote(string symbol, DateTime datetime, double open, double high, double low,
            double close, double last, double volume, double size, double bid, double ask, double bidSize,
            double askSize, double openInt, double goBuy, double goSell, double goBase, double goBaseBacked,
            double highLimit, double lowLimit, int tradingStatus, double volatility, double theoreticalPrice,
            double stepPrice)
        {
            ProduceMessage(
                TopicName.UpdateQuote,
                JsonSerializer.Serialize(
                    new UpdateQuote
                    {
                        Symbol = symbol,
                        DateTime = datetime,
                        PriceOpen = open,
                        PriceHigh = high,
                        PriceLow = low,
                        PriceClose = close,
                        PriceLast = last,
                        LastSize = size,
                        SessionVolume = volume,
                        PriceBid = bid,
                        PriceAsk = ask,
                        SizeBid = bidSize,
                        SizeAsk = askSize,
                        OpenedPrice = openInt,
                        GuaranteeBuy = goBuy,
                        GuaranteeSell = goSell,
                        PriceHighLimit = highLimit,
                        PriceLowLimit = lowLimit,
                        IsTrading = tradingStatus == 0,
                        Volatility = volatility,
                        TheoreticalPrice = theoreticalPrice,
                        StepPrice = stepPrice
                    }
                )
            );
        }

        private void OnUpdateOrder(string portfolio, string symbol, StOrder_State state, StOrder_Action action,
            StOrder_Type type, StOrder_Validity validity, double price, double amount, double stop, double filled,
            DateTime datetime, string orderId, string orderStockId, int statusMask, int cookie, string description)
        {
            ProduceMessage(
                TopicName.UpdateOrder,
                JsonSerializer.Serialize(
                    new UpdateOrder
                    {
                        Portfolio = portfolio,
                        Symbol = symbol,
                        State = state,
                        Action = action,
                        Type = type,
                        Validity = validity,
                        Price = price,
                        Amount = amount,
                        PriceStop = stop,
                        FilledVolume = filled,
                        DateTime = datetime,
                        OrderId = orderId,
                        StockOrderId = orderStockId,
                        StatusMask = statusMask,
                        UniqueId = cookie,
                        Error = description
                    }
                )
            );
        }

        private void OnUpdatePosition(string portfolio, string symbol, double averagePrice, double amount,
            double planned)
        {
            ProduceMessage(
                TopicName.UpdatePosition,
                JsonSerializer.Serialize(
                    new UpdatePosition
                    {
                        Portfolio = portfolio,
                        Symbol = symbol,
                        AveragePrice = averagePrice,
                        Amount = amount,
                        PlannedAmount = planned
                    }
                )
            );
        }

        private void OnUpdateBidAsk(string symbol, int row, int rowsCount, double bid, double bidSize, double ask,
            double askSize)
        {
            ProduceMessage(
                TopicName.UpdateBidAsk,
                JsonSerializer.Serialize(
                    new UpdateBidAsk
                    {
                        Row = row,
                        RowsCount = rowsCount,
                        Symbol = symbol,
                        BidPrice = bid,
                        BidSize = bidSize,
                        AskPrice = ask,
                        AskSize = askSize
                    }
                )
            );
        }

        private void OnSetPortfolio(string portfolio, double cash, double leverage, double commission,
            double profit, double liquidationPrice, double initialMargin, double totalAssets)
        {
            ProduceMessage(
                TopicName.SetPortfolio,
                JsonSerializer.Serialize(
                    new SetPortfolio
                    {
                        Portfolio = portfolio,
                        Money = cash,
                        Leverage = leverage,
                        Commission = commission,
                        Profit = profit,
                        LiquidationPrice = liquidationPrice,
                        InitialMargin = initialMargin,
                        TotalAssets = totalAssets
                    }
                )
            );
        }

        private void OnSetMyTrade(int row, int rowsCount, string portfolio, string symbol, DateTime datetime,
            double price, double volume, string tradeId, StOrder_Action action, string orderStockId, double value,
            double accruedCoupon)
        {
            ProduceMessage(
                TopicName.SetMyTrade,
                JsonSerializer.Serialize(
                    new SetMyTrade
                    {
                        Row = row,
                        RowsCount = rowsCount,
                        Portfolio = portfolio,
                        Symbol = symbol,
                        DateTime = datetime,
                        Price = price,
                        Volume = volume,
                        OrderId = tradeId,
                        StockOrderId = orderStockId,
                        Action = action,
                        Value = value,
                        AccruedCoupon = accruedCoupon
                    }
                )
            );
        }

        private void OnSetMyOrder(int row, int rowsCount, string portfolio, string symbol, StOrder_State state,
            StOrder_Action action, StOrder_Type type, StOrder_Validity validity, double price, double amount,
            double stop, double filled, DateTime datetime, string id, string no, int cookie)
        {
            ProduceMessage(
                TopicName.SetMyOrder,
                JsonSerializer.Serialize(
                    new SetMyOrder
                    {
                        Row = row,
                        RowsCount = rowsCount,
                        Portfolio = portfolio,
                        Symbol = symbol,
                        State = state,
                        Action = action,
                        Type = type,
                        Validity = validity,
                        Price = price,
                        Amount = amount,
                        PriceStop = stop,
                        FilledVolume = filled,
                        DateTime = datetime,
                        OrderId = id,
                        StockOrderId = no,
                        UniqueId = cookie
                    }
                )
            );
        }

        private void OnSetMyClosePos(int row, int rowsCount, string portfolio, string symbol, double amount,
            double priceBuy, double priceSell, DateTime positionTime, string orderOpen, string orderClose)
        {
            ProduceMessage(
                TopicName.SetMyClosePos,
                JsonSerializer.Serialize(
                    new SetMyClosePosition
                    {
                        Row = row,
                        RowsCount = rowsCount,
                        Portfolio = portfolio,
                        Symbol = symbol,
                        Amount = amount,
                        PriceBuy = priceBuy,
                        PriceSell = priceBuy,
                        DateTime = positionTime,
                        OpenOrderId = orderOpen,
                        CloseOrderId = orderClose
                    }
                )
            );
        }

        private void OnOrderSucceeded(int cookie, string orderId)
        {
            ProduceMessage(
                TopicName.OrderSucceeded,
                JsonSerializer.Serialize(
                    new OrderSucceeded
                    {
                        UniqueId = cookie,
                        OrderId = orderId
                    }
                )
            );
        }

        private void OnOrderFailed(int cookie, string orderId, string reason)
        {
            ProduceMessage(
                TopicName.OrderFailed,
                JsonSerializer.Serialize(
                    new OrderFailed
                    {
                        UniqueId = cookie,
                        OrderId = orderId,
                        Reason = reason
                    }
                )
            );
        }

        private void OnOrderCancelFailed(string orderId)
        {
            ProduceMessage(
                TopicName.OrderCancelFailed,
                JsonSerializer.Serialize(
                    new OrderCancelFailed {OrderId = orderId}
                )
            );
        }

        private void OnOrderCancelSucceeded(string orderId)
        {
            ProduceMessage(
                TopicName.OrderCancelSucceeded,
                JsonSerializer.Serialize(
                    new OrderCancelSucceeded {OrderId = orderId}
                )
            );
        }

        private void OnOrderMoveFailed(string orderId)
        {
            ProduceMessage(
                TopicName.OrderMoveFailed,
                JsonSerializer.Serialize(
                    new OrderMoveFailed {OrderId = orderId}
                )
            );
        }

        private void OnOrderMoveSucceeded(string orderId)
        {
            ProduceMessage(
                TopicName.OrderMoveSucceeded,
                JsonSerializer.Serialize(
                    new OrderMoveSucceeded {OrderId = orderId}
                )
            );
        }

        private void OnConnected()
        {
            _logger.Write("Connected to broker");
        }

        private void OnDisconnected(string reason)
        {
            _logger.Write("Disconnected from broker:", reason);
        }

        private void OnAddTrade(string portfolio, string symbol, string orderId, double price, double amount,
            DateTime datetime, string tradeId, double value, double accruedCoupon)
        {
            ProduceMessage(
                TopicName.AddTrade,
                JsonSerializer.Serialize(
                    new AddTrade
                    {
                        Portfolio = portfolio,
                        Symbol = symbol,
                        OrderId = orderId,
                        Price = price,
                        Amount = amount,
                        DateTime = datetime,
                        TradeId = tradeId,
                        Value = value,
                        AccruedCoupon = accruedCoupon
                    }
                )
            );
        }

        private void OnAddTickHistory(int row, int rowsCount, string symbol, DateTime datetime, double price,
            double volume, string tradeId, StOrder_Action action)
        {
            ProduceMessage(
                TopicName.AddTickHistory,
                JsonSerializer.Serialize(
                    new AddTickHistory
                    {
                        Row = row,
                        RowsCount = rowsCount,
                        Symbol = symbol,
                        DateTime = datetime,
                        Price = price,
                        Volume = volume,
                        TradeId = tradeId,
                        Action = action
                    })
            );
        }

        private void OnAddTick(string symbol, DateTime datetime, double price, double volume, string tradeId,
            StOrder_Action action)
        {
            ProduceMessage(
                TopicName.AddTick,
                JsonSerializer.Serialize(
                    new AddTick
                    {
                        Symbol = symbol,
                        DateTime = datetime,
                        Price = price,
                        Volume = volume,
                        TradeId = tradeId,
                        Action = action
                    }
                )
            );
        }

        private void OnAddSymbol(int row, int rowsCount, string symbol, string longName, string shortName,
            string type, int decimals, int lotSize, double priceStepPoint, double step, string secExtId,
            string secExchangeName, DateTime expiryDate, double daysBeforeExpiry, double strike)
        {
            ProduceMessage(
                TopicName.AddSymbol,
                JsonSerializer.Serialize(
                    new AddSymbol
                    {
                        Row = row,
                        RowsCount = rowsCount,
                        Isin = secExtId,
                        Symbol = symbol,
                        ShortName = shortName,
                        LongName = longName,
                        Type = type,
                        Decimals = decimals,
                        LotSize = lotSize,
                        PriceStep = step,
                        ExchangeName = secExchangeName,
                        ExpiryDate = expiryDate,
                        DaysBeforeExpiry = daysBeforeExpiry,
                        PriceStepPoint = priceStepPoint,
                        Strike = strike
                    }
                )
            );
        }

        private void OnAddBar(int row, int rowsCount, string symbol, StBarInterval interval, DateTime datetime,
            double open, double high, double low, double close, double volume, double openInt)
        {
            ProduceMessage(
                TopicName.AddBar,
                JsonSerializer.Serialize(
                    new AddBar
                    {
                        Row = row,
                        RowsCount = rowsCount,
                        Symbol = symbol,
                        Interval = interval,
                        DateTime = datetime,
                        OpenPrice = open,
                        HighPrice = high,
                        LowPrice = low,
                        ClosePrice = close,
                        Volume = volume,
                        Opened = openInt
                    }
                )
            );
        }

        private void OnAddPortfolio(
            int row,
            int rowsCount,
            string name,
            string exchange,
            StPortfolioStatus status)
        {
            ProduceMessage(
                TopicName.AddPortfolio,
                JsonSerializer.Serialize(
                    new AddPortfolio
                    {
                        Row = row,
                        RowsCount = rowsCount,
                        Name = name,
                        Exchange = exchange,
                        Status = status
                    }
                )
            );
        }

        private async void ProduceMessage(string topic, string msg)
        {
            try
            {
                var dr = await _producer.ProduceAsync(topic, new Message<Null, string> {Value = msg});
                
                _logger.Write($"Write {dr.Value} to topic {dr.Topic}");
            }
            catch (ProduceException<Null, string> e)
            {
                _logger.Error($"Delivery failed: {e.Error.Reason}");
            }
        }
    }
}