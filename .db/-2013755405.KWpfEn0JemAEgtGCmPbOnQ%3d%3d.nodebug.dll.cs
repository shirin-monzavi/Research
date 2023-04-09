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

public class Index_ExpiryEventLogItemsIndex : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_ExpiryEventLogItemsIndex()
	{
		this.ViewText = @"from message in docs.EventLogItems
select new {
	LastModified = (message[""@metadata""].Value<DateTime>(""Last-Modified"")).Ticks
}";
		this.ForEntityNames.Add("EventLogItems");
		this.AddMapDefinition(docs => 
			from message in ((IEnumerable<dynamic>)docs)
			where string.Equals(message["@metadata"]["Raven-Entity-Name"], "EventLogItems", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				LastModified = (message["@metadata"].Value<DateTime>("Last-Modified")).Ticks,
				__document_id = message.__document_id
			});
		this.AddField("LastModified");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("Ticks");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("Ticks");
		this.AddQueryParameterForReduce("__document_id");
	}
}
