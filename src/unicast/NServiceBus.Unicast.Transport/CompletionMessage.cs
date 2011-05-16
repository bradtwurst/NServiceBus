using System;
using System.Runtime.Serialization;

namespace NServiceBus.Unicast.Transport
{
	/// <summary>
	/// A message that will be sent on completion or error of an NServiceBus message.
	/// </summary>
    [Serializable]
    [DataContract]
    public class CompletionMessage : IMessage
    {
		/// <summary>
		/// Gets/sets a code specifying the type of error that occurred.
		/// </summary>
        /// 
        [DataMember(Order=1)]
        public int ErrorCode { get; set; }
    }
}
