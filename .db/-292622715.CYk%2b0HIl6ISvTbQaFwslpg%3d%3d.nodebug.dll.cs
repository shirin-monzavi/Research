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

public class Index_GroupCommentIndex : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_GroupCommentIndex()
	{
		this.ViewText = @"from gc in docs.GroupComments
select new {
	Id = gc.__document_id,
	Comment = gc.Comment
}";
		this.ForEntityNames.Add("GroupComments");
		this.AddMapDefinition(docs => 
			from gc in ((IEnumerable<dynamic>)docs)
			where string.Equals(gc["@metadata"]["Raven-Entity-Name"], "GroupComments", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				Id = gc.__document_id,
				Comment = gc.Comment,
				__document_id = gc.__document_id
			});
		this.AddField("Id");
		this.AddField("Comment");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForMap("Comment");
		this.AddQueryParameterForReduce("__document_id");
		this.AddQueryParameterForReduce("Comment");
	}
}
