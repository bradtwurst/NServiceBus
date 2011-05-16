using System;
using System.Runtime.Serialization;

namespace NServiceBus.Messages
{
	/// <summary>
	/// Defines a message indicating that a transport is ready to
	/// receive a message.
	/// </summary>
    [DataContract]
    [Serializable]
    public class ReadyMessage : IMessage 
    {
        /// <summary>
        /// Exposes whether or not previous ready messages from the same
        /// sender should be cleared.
        /// </summary>
        [DataMember(Order = 1)]
        public bool ClearPreviousFromThisAddress { get; set; }
    }
}
