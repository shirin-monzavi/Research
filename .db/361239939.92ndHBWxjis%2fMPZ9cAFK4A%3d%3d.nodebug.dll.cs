using Raven.Abstractions;
using Raven.Database.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using Raven.Database.Linq.PrivateExtensions;
using Lucene.Net.Documents;
using System.Globalization;
using System.Text.RegularExpressions;
using Raven.Database.Indexing;

public class Index_FailedMessageViewIndex : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_FailedMessageViewIndex()
	{
		this.ViewText = @"from message in docs.FailedMessages
select new {
	message = message,
	processingAttemptsLast = DynamicEnumerable.LastOrDefault(message.ProcessingAttempts)
} into this0
select new {
	MessageId = this0.processingAttemptsLast.MessageMetadata[""MessageId""],
	MessageType = this0.processingAttemptsLast.MessageMetadata[""MessageType""],
	Status = this0.message.Status,
	TimeSent = ((DateTime)this0.processingAttemptsLast.MessageMetadata[""TimeSent""]),
	ReceivingEndpointName = ((this0.processingAttemptsLast.MessageMetadata[""ReceivingEndpoint""])).Name,
	QueueAddress = this0.processingAttemptsLast.FailureDetails.AddressOfFailingEndpoint,
	TimeOfFailure = this0.processingAttemptsLast.FailureDetails.TimeOfFailure,
	LastModified = (this0.message[""@metadata""].Value<DateTime>(""Last-Modified"")).Ticks
}";
		this.ForEntityNames.Add("FailedMessages");
		this.AddMapDefinition(docs => 
			from message in ((IEnumerable<dynamic>)docs)
			where string.Equals(message["@metadata"]["Raven-Entity-Name"], "FailedMessages", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				message = message,
				processingAttemptsLast = DynamicEnumerable.LastOrDefault(message.ProcessingAttempts),
				__document_id = message.__document_id
			} into this0
			select new {
				MessageId = this0.processingAttemptsLast.MessageMetadata["MessageId"],
				MessageType = this0.processingAttemptsLast.MessageMetadata["MessageType"],
				Status = this0.message.Status,
				TimeSent = ((DateTime)this0.processingAttemptsLast.MessageMetadata["TimeSent"]),
				ReceivingEndpointName = ((this0.processingAttemptsLast.MessageMetadata["ReceivingEndpoint"])).Name,
				QueueAddress = this0.processingAttemptsLast.FailureDetails.AddressOfFailingEndpoint,
				TimeOfFailure = this0.processingAttemptsLast.FailureDetails.TimeOfFailure,
				LastModified = (this0.message["@metadata"].Value<DateTime>("Last-Modified")).Ticks,
				__document_id = this0.__document_id
			});
		this.AddField("MessageId");
		this.AddField("MessageType");
		this.AddField("Status");
		this.AddField("TimeSent");
		this.AddField("ReceivingEndpointName");
		this.AddField("QueueAddress");
		this.AddField("TimeOfFailure");
		this.AddField("LastModified");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForMap("message.Status");
		this.AddQueryParameterForMap("Name");
		this.AddQueryParameterForMap("processingAttemptsLast.FailureDetails.AddressOfFailingEndpoint");
		this.AddQueryParameterForMap("processingAttemptsLast.FailureDetails.TimeOfFailure");
		this.AddQueryParameterForMap("Ticks");
		this.AddQueryParameterForReduce("__document_id");
		this.AddQueryParameterForReduce("message.Status");
		this.AddQueryParameterForReduce("Name");
		this.AddQueryParameterForReduce("processingAttemptsLast.FailureDetails.AddressOfFailingEndpoint");
		this.AddQueryParameterForReduce("processingAttemptsLast.FailureDetails.TimeOfFailure");
		this.AddQueryParameterForReduce("Ticks");
	}
}
