using System;
using System.Runtime.Serialization;

namespace NServiceBus.Grid.Messages
{
    /// <summary>
    /// Request message sent to a bus to get
    /// the number of worker threads. Response is a <see cref="GotNumberOfWorkerThreadsMessage"/>.
    /// </summary>
    [Serializable]
    [DataContract]
    public class GetNumberOfWorkerThreadsMessage : IMessage
    {
    }
}
