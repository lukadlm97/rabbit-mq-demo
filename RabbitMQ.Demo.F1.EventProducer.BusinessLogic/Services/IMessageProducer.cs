using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Demo.F1.EventProducer.BusinessLogic.Models.Input;

namespace RabbitMQ.Demo.F1.EventProducer.BusinessLogic.Services
{
    public interface IMessageProducer
    {
        Task<bool> SendMessage(EventRequest request);
    }
}
