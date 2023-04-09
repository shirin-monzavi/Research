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

public class Index_FailedMessageFacetsIndex : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_FailedMessageFacetsIndex()
	{
		this.ViewText = @"from failure in docs.FailedMessages
where failure.Status == 1
select new {
	failure = failure,
	t = ((DynamicEnumerable.LastOrDefault(failure.ProcessingAttempts)).MessageMetadata[""ReceivingEndpoint""])
} into this0
select new {
	Name = this0.t.Name,
	Host = this0.t.Host,
	MessageType = (DynamicEnumerable.LastOrDefault(this0.failure.ProcessingAttempts)).MessageMetadata[""MessageType""]
}";
		this.ForEntityNames.Add("FailedMessages");
		this.AddMapDefinition(docs => 
			from failure in ((IEnumerable<dynamic>)docs)
			where string.Equals(failure["@metadata"]["Raven-Entity-Name"], "FailedMessages", System.StringComparison.InvariantCultureIgnoreCase)
			where failure.Status == 1
			select new {
				failure = failure,
				t = ((DynamicEnumerable.LastOrDefault(failure.ProcessingAttempts)).MessageMetadata["ReceivingEndpoint"]),
				__document_id = failure.__document_id
			} into this0
			select new {
				Name = this0.t.Name,
				Host = this0.t.Host,
				MessageType = (DynamicEnumerable.LastOrDefault(this0.failure.ProcessingAttempts)).MessageMetadata["MessageType"],
				__document_id = this0.__document_id
			});
		this.AddField("Name");
		this.AddField("Host");
		this.AddField("MessageType");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForMap("t.Name");
		this.AddQueryParameterForMap("t.Host");
		this.AddQueryParameterForReduce("__document_id");
		this.AddQueryParameterForReduce("t.Name");
		this.AddQueryParameterForReduce("t.Host");
	}
}
