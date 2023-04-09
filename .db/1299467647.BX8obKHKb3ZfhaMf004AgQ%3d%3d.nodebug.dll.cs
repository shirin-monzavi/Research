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

public class Index_FailedMessages_ByGroup : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_FailedMessages_ByGroup()
	{
		this.ViewText = @"from doc in docs.FailedMessages
select new {
	doc = doc,
	processingAttemptsLast = DynamicEnumerable.LastOrDefault(doc.ProcessingAttempts)
} into this0
from failureGroup in this0.doc.FailureGroups
select new {
	Id = this0.doc.__document_id,
	MessageId = this0.doc.UniqueMessageId,
	FailureGroupId = failureGroup.Id,
	FailureGroupName = failureGroup.Title,
	Status = this0.doc.Status,
	MessageType = ((string)this0.processingAttemptsLast.MessageMetadata[""MessageType""]),
	TimeSent = ((DateTime)this0.processingAttemptsLast.MessageMetadata[""TimeSent""]),
	TimeOfFailure = this0.processingAttemptsLast.FailureDetails.TimeOfFailure,
	LastModified = (this0.doc[""@metadata""].Value<DateTime>(""Last-Modified"")).Ticks
}";
		this.ForEntityNames.Add("FailedMessages");
		this.AddMapDefinition(docs => 
			from doc in ((IEnumerable<dynamic>)docs)
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "FailedMessages", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				doc = doc,
				processingAttemptsLast = DynamicEnumerable.LastOrDefault(doc.ProcessingAttempts),
				__document_id = doc.__document_id
			} into this0
			from failureGroup in ((IEnumerable<dynamic>)this0.doc.FailureGroups)
			select new {
				Id = this0.doc.__document_id,
				MessageId = this0.doc.UniqueMessageId,
				FailureGroupId = failureGroup.Id,
				FailureGroupName = failureGroup.Title,
				Status = this0.doc.Status,
				MessageType = ((string)this0.processingAttemptsLast.MessageMetadata["MessageType"]),
				TimeSent = ((DateTime)this0.processingAttemptsLast.MessageMetadata["TimeSent"]),
				TimeOfFailure = this0.processingAttemptsLast.FailureDetails.TimeOfFailure,
				LastModified = (this0.doc["@metadata"].Value<DateTime>("Last-Modified")).Ticks,
				__document_id = this0.__document_id
			});
		this.AddField("Id");
		this.AddField("MessageId");
		this.AddField("FailureGroupId");
		this.AddField("FailureGroupName");
		this.AddField("Status");
		this.AddField("MessageType");
		this.AddField("TimeSent");
		this.AddField("TimeOfFailure");
		this.AddField("LastModified");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForMap("doc.__document_id");
		this.AddQueryParameterForMap("doc.UniqueMessageId");
		this.AddQueryParameterForMap("Id");
		this.AddQueryParameterForMap("Title");
		this.AddQueryParameterForMap("doc.Status");
		this.AddQueryParameterForMap("processingAttemptsLast.FailureDetails.TimeOfFailure");
		this.AddQueryParameterForMap("Ticks");
		this.AddQueryParameterForReduce("__document_id");
		this.AddQueryParameterForReduce("doc.__document_id");
		this.AddQueryParameterForReduce("doc.UniqueMessageId");
		this.AddQueryParameterForReduce("Id");
		this.AddQueryParameterForReduce("Title");
		this.AddQueryParameterForReduce("doc.Status");
		this.AddQueryParameterForReduce("processingAttemptsLast.FailureDetails.TimeOfFailure");
		this.AddQueryParameterForReduce("Ticks");
	}
}
