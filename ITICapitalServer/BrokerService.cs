using System;
using System.Threading.Tasks;
using Grpc.Core;
using Iticapital;
using ITICapitalServer.Logging;
using SmartCOM4Lib;

namespace ITICapitalServer
{
    public class BrokerService : ITICapitalAPI.ITICapitalAPIBase
    {
        private readonly IStServer _stServer;
        private readonly ILogger _logger;

        public BrokerService(IStServer stServer, ILogger logger)
        {
            _stServer = stServer;
            _logger = logger;
        }

        public override Task<Nothing> CancelBidAsk(Symbol request, ServerCallContext context)
        {
            _logger.Write($"Call CancelBidAsks({request.Value})");

            try
            {
                _stServer.CancelBidAsks(request.Value);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            return Task.FromResult(new Nothing());
        }

        public override Task<ResponseWithFailed> CancelOrder(OrderCancelRequest request, ServerCallContext context)
        {
            _logger.Write($"Call CancelBidAsks({request.Portfolio.Value}, {request.Symbol.Value}, {request.OrderId})");

            try
            {
                _stServer.CancelOrder(request.Portfolio.Value, request.Symbol.Value, request.OrderId);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            return Task.FromResult(new ResponseWithFailed
            {
                QueueSucceed = TopicName.OrderCancelSucceeded,
                QueueFailed = TopicName.OrderCancelFailed
            });
        }

        public override Task<Nothing> CancelPortfolio(Portfolio request, ServerCallContext context)
        {
            _logger.Write($"Call CancelPortfolio({request.Value})");

            try
            {
                _stServer.CancelPortfolio(request.Value);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            return Task.FromResult(new Nothing());
        }

        public override Task<Nothing> CancelQuotes(Symbol request, ServerCallContext context)
        {
            _logger.Write($"Call CancelQuotes({request.Value})");

            try
            {
                _stServer.CancelQuotes(request.Value);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            return Task.FromResult(new Nothing());
        }

        public override Task<Nothing> CancelTicks(Symbol request, ServerCallContext context)
        {
            _logger.Write($"Call CancelTicks({request.Value})");

            try
            {
                _stServer.CancelTicks(request.Value);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            return Task.FromResult(new Nothing());
        }

        public override Task<Response> GetBars(GetBarsRequest request, ServerCallContext context)
        {
            _logger.Write(
                $"Call GetBars({request.Symbol.Value}, {(StBarInterval) request.Interval}, {new DateTime(request.Since)}, {(int) request.Count})"
            );

            try
            {
                _stServer.GetBars(
                    request.Symbol.Value,
                    (StBarInterval) request.Interval,
                    new DateTime(request.Since),
                    (int) request.Count
                );
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            return Task.FromResult(new Response {Queue = TopicName.AddBar});
        }

        public override Task<GetMyPortfolioDataResponse> GetMyPortfolioData(
            GetMyPortfolioDataRequest request,
            ServerCallContext context
        )
        {
            _logger.Write(
                $"Call GetMyPortfolioData({(StOrder_Mode) request.Mode}, {request.Portfolio.Value})"
            );

            try
            {
                _stServer.GetMyPortfolioData((StOrder_Mode) request.Mode, request.Portfolio.Value);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            return Task.FromResult(new GetMyPortfolioDataResponse
            {
                MyTradeQueue = TopicName.SetMyTrade,
                MyClosePosQueue = TopicName.SetMyClosePos,
                MyOrderQueue = TopicName.SetMyOrder
            });
        }

        public override Task<Response> GetTrades(GetTradesRequest request, ServerCallContext context)
        {
            var dt = DateTime.Parse(request.From);

            _logger.Write($"Call GetTrades({request.Symbol.Value}, {dt}, {request.Count})");

            try
            {
                _stServer.GetTrades(request.Symbol.Value, dt, request.Count);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            return Task.FromResult(new Response {Queue = TopicName.AddTickHistory});
        }

        public override Task<Response> GetPortfolioList(Nothing request, ServerCallContext context)
        {
            _logger.Write("Call GetPortfolioList()");

            try
            {
                _stServer.GetPrortfolioList();
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            return Task.FromResult(new Response() {Queue = TopicName.AddPortfolio});
        }

        public override Task<Response> GetSymbols(Nothing request, ServerCallContext context)
        {
            _logger.Write("Call GetSymbols()");

            try
            {
                _stServer.GetSymbols();
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            return Task.FromResult(new Response() {Queue = TopicName.AddSymbol});
        }

        public override Task<IsConnectedResponse> IsConnected(Nothing request, ServerCallContext context)
        {
            return Task.FromResult(new IsConnectedResponse {Value = _stServer.IsConnected()});
        }

        public override Task<Response> ListenBidAsks(Symbol request, ServerCallContext context)
        {
            _logger.Write($"Call ListenBidAsks({request.Value})");

            try
            {
                _stServer.ListenBidAsks(request.Value);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            return Task.FromResult(new Response() {Queue = TopicName.UpdateBidAsk});
        }

        public override Task<ListenPortfolioResponse> ListenPortfolio(Portfolio request, ServerCallContext context)
        {
            _logger.Write($"Call ListenPortfolio({request.Value})");

            try
            {
                _stServer.ListenPortfolio(request.Value);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            return Task.FromResult(new ListenPortfolioResponse
            {
                SetPortfolioQueue = TopicName.SetPortfolio,
                AddTradeQueue = TopicName.AddTrade,
                UpdateOrderQueue = TopicName.UpdateOrder,
                UpdatePositionQueue = TopicName.UpdatePosition
            });
        }

        public override Task<Response> ListenQuotes(Symbol request, ServerCallContext context)
        {
            _logger.Write($"Call ListenQuotes({request.Value})");

            try
            {
                _stServer.ListenQuotes(request.Value);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }


            return Task.FromResult(new Response {Queue = TopicName.UpdateQuote});
        }

        public override Task<Response> ListenTicks(Symbol request, ServerCallContext context)
        {
            _logger.Write($"Call ListenTicks({request.Value})");

            try
            {
                _stServer.ListenTicks(request.Value);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            return Task.FromResult(new Response {Queue = TopicName.AddTick});
        }

        public override Task<ResponseWithFailed> MoveOrder(MoveOrderRequest request, ServerCallContext context)
        {
            _logger.Write(
                $"Call MoveOrder({request.Portfolio.Value}, {request.Symbol.Value}, {request.OrderId}, {request.TargetPrice})"
            );

            try
            {
                _stServer.MoveOrder(
                    request.Portfolio.Value,
                    request.Symbol.Value,
                    request.OrderId,
                    request.TargetPrice
                );
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            return Task.FromResult(new ResponseWithFailed
            {
                QueueSucceed = TopicName.OrderMoveSucceeded,
                QueueFailed = TopicName.OrderMoveFailed
            });
        }

        public override Task<ResponseWithFailed> PlaceOrder(PlaceOrderRequest request, ServerCallContext context)
        {
            var orderAction = (StOrder_Action) request.Action;
            var orderType = (StOrder_Type) request.Type;
            var orderValidity = (StOrder_Validity) request.Validity;
            
            _logger.Write(
                $"Call PlaceOrder(request.Portfolio.Value, {request.Symbol.Value}, {orderAction}, {orderType}, {orderValidity}, {request.Price}, {request.Amount}, {request.PriceStop}, {request.UniqueId})"
            );
            
            try
            {
                _stServer.PlaceOrder(
                    request.Portfolio.Value,
                    request.Symbol.Value,
                    orderAction,
                    orderType,
                    orderValidity,
                    request.Price,
                    request.Amount,
                    request.PriceStop,
                    request.UniqueId
                ); 
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            return Task.FromResult(new ResponseWithFailed
            {
                QueueSucceed = TopicName.OrderSucceeded,
                QueueFailed = TopicName.OrderFailed
            });
        }
    }
}