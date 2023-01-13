using Grpc.Core;
using RabbitMQ.Demo.F1.EventProducer.BusinessLogic.Models.Input;
using RabbitMQ.Demo.F1.EventProducer.BusinessLogic.Services;

namespace RabbitMQ.Demo.F1.EventProducer.Services
{
    public class F1EventHandlerService :F1EventHandler.F1EventHandlerBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly IMessageProducer _messageProducer;

        public F1EventHandlerService(ILogger<GreeterService> logger,IMessageProducer messageProducer)
        {
            _logger = logger;
            _messageProducer = messageProducer;
        }

        public override async Task<RaceResponse> ProcessRaceEvent(RaceRequest request, ServerCallContext context)
        {
            var successfullyCompleted = false;
            var message = string.Empty;
            try
            {
                successfullyCompleted = await _messageProducer.SendMessage(new EventRequest()
                {
                    Description = request.Description,
                    Sender = "F1EventHandlerService"
                });
            }
            catch (Exception ex)
            {
                message=ex.Message;
                successfullyCompleted = false;
            }

            return successfullyCompleted switch
            {
                true => new RaceResponse()
                {
                    Status = RaceEventResponseStatus.Success,
                    Message = "We successfully sent request to message bus with description: " + request.Description
                },
                _=> new RaceResponse()
                {
                    Status = RaceEventResponseStatus.BadRequest,
                    Message = message
                }
            };
        }
    }
}
