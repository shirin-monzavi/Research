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

public class Index_QueueAddressIndex : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_QueueAddressIndex()
	{
		this.ViewText = @"from message in docs.FailedMessages
select new {
	message = message,
	processingAttemptsLast = DynamicEnumerable.LastOrDefault(message.ProcessingAttempts)
} into this0
select new {
	PhysicalAddress = this0.processingAttemptsLast.FailureDetails.AddressOfFailingEndpoint,
	FailedMessageCount = 1
}
from result in results
group result by result.PhysicalAddress into g
select new {
	PhysicalAddress = g.Key,
	FailedMessageCount = Enumerable.Sum(g, m => ((int)m.FailedMessageCount))
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
				PhysicalAddress = this0.processingAttemptsLast.FailureDetails.AddressOfFailingEndpoint,
				FailedMessageCount = 1,
				__document_id = this0.__document_id
			});
		this.ReduceDefinition = results => 
			from result in results
			group result by result.PhysicalAddress into g
			select new {
				PhysicalAddress = g.Key,
				FailedMessageCount = Enumerable.Sum(g, (Func<dynamic, int>)(m => ((int)m.FailedMessageCount)))
			};
		this.GroupByExtraction = result => result.PhysicalAddress;
		this.AddField("PhysicalAddress");
		this.AddField("FailedMessageCount");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForMap("processingAttemptsLast.FailureDetails.AddressOfFailingEndpoint");
		this.AddQueryParameterForReduce("__document_id");
		this.AddQueryParameterForReduce("processingAttemptsLast.FailureDetails.AddressOfFailingEndpoint");
	}
}
