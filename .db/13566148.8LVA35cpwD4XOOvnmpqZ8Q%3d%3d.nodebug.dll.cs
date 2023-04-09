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

public class Index_CustomChecksIndex : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_CustomChecksIndex()
	{
		this.ViewText = @"from cc in docs.CustomChecks
select new {
	Status = cc.Status,
	ReportedAt = cc.ReportedAt,
	Category = cc.Category,
	CustomCheckId = cc.CustomCheckId
}";
		this.ForEntityNames.Add("CustomChecks");
		this.AddMapDefinition(docs => 
			from cc in ((IEnumerable<dynamic>)docs)
			where string.Equals(cc["@metadata"]["Raven-Entity-Name"], "CustomChecks", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				Status = cc.Status,
				ReportedAt = cc.ReportedAt,
				Category = cc.Category,
				CustomCheckId = cc.CustomCheckId,
				__document_id = cc.__document_id
			});
		this.AddField("Status");
		this.AddField("ReportedAt");
		this.AddField("Category");
		this.AddField("CustomCheckId");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("Status");
		this.AddQueryParameterForMap("ReportedAt");
		this.AddQueryParameterForMap("Category");
		this.AddQueryParameterForMap("CustomCheckId");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("Status");
		this.AddQueryParameterForReduce("ReportedAt");
		this.AddQueryParameterForReduce("Category");
		this.AddQueryParameterForReduce("CustomCheckId");
		this.AddQueryParameterForReduce("__document_id");
	}
}
