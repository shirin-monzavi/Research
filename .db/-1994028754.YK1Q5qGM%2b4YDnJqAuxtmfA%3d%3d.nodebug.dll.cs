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

public class Index_FailedAuditImportIndex : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_FailedAuditImportIndex()
	{
		this.ViewText = @"from cc in docs.FailedAuditImports
select new {
	Id = cc.__document_id,
	Message = cc.Message
}";
		this.ForEntityNames.Add("FailedAuditImports");
		this.AddMapDefinition(docs => 
			from cc in ((IEnumerable<dynamic>)docs)
			where string.Equals(cc["@metadata"]["Raven-Entity-Name"], "FailedAuditImports", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				Id = cc.__document_id,
				Message = cc.Message,
				__document_id = cc.__document_id
			});
		this.AddField("Id");
		this.AddField("Message");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForMap("Message");
		this.AddQueryParameterForReduce("__document_id");
		this.AddQueryParameterForReduce("Message");
	}
}
