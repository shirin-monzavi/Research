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

public class Index_FailedMessageRetries_ByBatch : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_FailedMessageRetries_ByBatch()
	{
		this.ViewText = @"from doc in docs.FailedMessageRetries
select new {
	RetryBatchId = doc.RetryBatchId
}";
		this.ForEntityNames.Add("FailedMessageRetries");
		this.AddMapDefinition(docs => 
			from doc in ((IEnumerable<dynamic>)docs)
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "FailedMessageRetries", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				RetryBatchId = doc.RetryBatchId,
				__document_id = doc.__document_id
			});
		this.AddField("RetryBatchId");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("RetryBatchId");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("RetryBatchId");
		this.AddQueryParameterForReduce("__document_id");
	}
}
