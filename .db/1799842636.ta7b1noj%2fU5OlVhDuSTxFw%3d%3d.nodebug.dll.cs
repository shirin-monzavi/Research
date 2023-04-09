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

public class Index_ExpiryErrorMessageIndex : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_ExpiryErrorMessageIndex()
	{
		this.ViewText = @"from message in docs.FailedMessages
where message.Status != 1
select new {
	Status = message.Status,
	LastModified = (message[""@metadata""].Value<DateTime>(""Last-Modified"")).Ticks
}";
		this.ForEntityNames.Add("FailedMessages");
		this.AddMapDefinition(docs => 
			from message in ((IEnumerable<dynamic>)docs)
			where string.Equals(message["@metadata"]["Raven-Entity-Name"], "FailedMessages", System.StringComparison.InvariantCultureIgnoreCase)
			where message.Status != 1
			select new {
				Status = message.Status,
				LastModified = (message["@metadata"].Value<DateTime>("Last-Modified")).Ticks,
				__document_id = message.__document_id
			});
		this.AddField("Status");
		this.AddField("LastModified");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("Status");
		this.AddQueryParameterForMap("Ticks");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("Status");
		this.AddQueryParameterForReduce("Ticks");
		this.AddQueryParameterForReduce("__document_id");
	}
}
