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

public class Transformer_FailedMessageViewTransformer : Raven.Database.Linq.AbstractTransformer
{
	public Transformer_FailedMessageViewTransformer()
	{
		this.ViewText = @"from failure in results
select new {
	failure = failure,
	rec = DynamicEnumerable.LastOrDefault(failure.ProcessingAttempts)
} into this0
select new {
	this0 = this0,
	edited = this0.rec.Headers[""ServiceControl.EditOf""] != null
} into this1
select new {
	Id = this1.this0.failure.UniqueMessageId,
	MessageType = this1.this0.rec.MessageMetadata[""MessageType""],
	IsSystemMessage = ((bool)this1.this0.rec.MessageMetadata[""IsSystemMessage""]),
	SendingEndpoint = this1.this0.rec.MessageMetadata[""SendingEndpoint""],
	ReceivingEndpoint = this1.this0.rec.MessageMetadata[""ReceivingEndpoint""],
	TimeSent = ((DateTime?)this1.this0.rec.MessageMetadata[""TimeSent""]),
	MessageId = this1.this0.rec.MessageMetadata[""MessageId""],
	Exception = this1.this0.rec.FailureDetails.Exception,
	QueueAddress = this1.this0.rec.FailureDetails.AddressOfFailingEndpoint,
	NumberOfProcessingAttempts = this1.this0.failure.ProcessingAttempts.Count,
	Status = this1.this0.failure.Status,
	TimeOfFailure = this1.this0.rec.FailureDetails.TimeOfFailure,
	LastModified = this1.this0.failure[""@metadata""][""Last-Modified""].Value<DateTime>(),
	Edited = this1.edited,
	EditOf = this1.edited ? this1.this0.rec.Headers[""ServiceControl.EditOf""] : """"
}
";
		this.TransformResultsDefinition = results => 
			from failure in ((IEnumerable<dynamic>)results)
			select new {
				failure = failure,
				rec = DynamicEnumerable.LastOrDefault(failure.ProcessingAttempts)
			} into this0
			select new {
				this0 = this0,
				edited = this0.rec.Headers["ServiceControl.EditOf"] != null
			} into this1
			select new {
				Id = this1.this0.failure.UniqueMessageId,
				MessageType = this1.this0.rec.MessageMetadata["MessageType"],
				IsSystemMessage = ((bool)this1.this0.rec.MessageMetadata["IsSystemMessage"]),
				SendingEndpoint = this1.this0.rec.MessageMetadata["SendingEndpoint"],
				ReceivingEndpoint = this1.this0.rec.MessageMetadata["ReceivingEndpoint"],
				TimeSent = ((DateTime?)this1.this0.rec.MessageMetadata["TimeSent"]),
				MessageId = this1.this0.rec.MessageMetadata["MessageId"],
				Exception = this1.this0.rec.FailureDetails.Exception,
				QueueAddress = this1.this0.rec.FailureDetails.AddressOfFailingEndpoint,
				NumberOfProcessingAttempts = this1.this0.failure.ProcessingAttempts.Count,
				Status = this1.this0.failure.Status,
				TimeOfFailure = this1.this0.rec.FailureDetails.TimeOfFailure,
				LastModified = this1.this0.failure["@metadata"]["Last-Modified"].Value<DateTime>(),
				Edited = this1.edited,
				EditOf = this1.edited ? this1.this0.rec.Headers["ServiceControl.EditOf"] : ""
			};
	}
}
