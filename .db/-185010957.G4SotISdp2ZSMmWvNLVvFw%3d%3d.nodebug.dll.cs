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

public class Index_ExpiryProcessedMessageIndex : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_ExpiryProcessedMessageIndex()
	{
		this.ViewText = @"from message in docs.ProcessedMessages
select new {
	ProcessedAt = message.ProcessedAt.Ticks
}";
		this.ForEntityNames.Add("ProcessedMessages");
		this.AddMapDefinition(docs => 
			from message in ((IEnumerable<dynamic>)docs)
			where string.Equals(message["@metadata"]["Raven-Entity-Name"], "ProcessedMessages", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				ProcessedAt = message.ProcessedAt.Ticks,
				__document_id = message.__document_id
			});
		this.AddField("ProcessedAt");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("ProcessedAt.Ticks");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("ProcessedAt.Ticks");
		this.AddQueryParameterForReduce("__document_id");
	}
}
