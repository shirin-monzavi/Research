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

public class Index_RetryBatches_ByStatusAndSession : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_RetryBatches_ByStatusAndSession()
	{
		this.ViewText = @"from doc in docs.RetryBatches
select new {
	RetrySessionId = doc.RetrySessionId,
	Status = doc.Status
}";
		this.ForEntityNames.Add("RetryBatches");
		this.AddMapDefinition(docs => 
			from doc in ((IEnumerable<dynamic>)docs)
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "RetryBatches", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				RetrySessionId = doc.RetrySessionId,
				Status = doc.Status,
				__document_id = doc.__document_id
			});
		this.AddField("RetrySessionId");
		this.AddField("Status");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("RetrySessionId");
		this.AddQueryParameterForMap("Status");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("RetrySessionId");
		this.AddQueryParameterForReduce("Status");
		this.AddQueryParameterForReduce("__document_id");
	}
}
