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

public class Index_Auto_EventLogItems_ByRaisedAtSortByRaisedAt : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Auto_EventLogItems_ByRaisedAtSortByRaisedAt()
	{
		this.ViewText = @"from doc in docs.EventLogItems
select new {
	RaisedAt = doc.RaisedAt
}";
		this.ForEntityNames.Add("EventLogItems");
		this.AddMapDefinition(docs => 
			from doc in ((IEnumerable<dynamic>)docs)
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "EventLogItems", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				RaisedAt = doc.RaisedAt,
				__document_id = doc.__document_id
			});
		this.AddField("RaisedAt");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("RaisedAt");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("RaisedAt");
		this.AddQueryParameterForReduce("__document_id");
	}
}
