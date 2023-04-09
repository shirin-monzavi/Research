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

public class Index_SagaListIndex : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_SagaListIndex()
	{
		this.ViewText = @"from doc in docs.SagaSnapshots
select new {
	Id = doc.SagaId,
	Uri = ""api/sagas/"" + doc.SagaId,
	SagaType = doc.SagaType
}
from doc in docs.SagaHistories
select new {
	Id = doc.SagaId,
	Uri = ""api/sagas/"" + doc.SagaId,
	SagaType = doc.SagaType
}
from result in results
group result by result.Id into g
select new {
	g = g,
	first = DynamicEnumerable.FirstOrDefault(g)
} into this0
select new {
	Id = this0.g.Key,
	Uri = this0.first.Uri,
	SagaType = this0.first.SagaType
}";
		this.ForEntityNames.Add("SagaSnapshots");
		this.AddMapDefinition(docs => 
			from doc in ((IEnumerable<dynamic>)docs)
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "SagaSnapshots", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				Id = doc.SagaId,
				Uri = "api/sagas/" + doc.SagaId,
				SagaType = doc.SagaType,
				__document_id = doc.__document_id
			});
		this.ForEntityNames.Add("SagaHistories");
		this.AddMapDefinition(docs => 
			from doc in ((IEnumerable<dynamic>)docs)
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "SagaHistories", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				Id = doc.SagaId,
				Uri = "api/sagas/" + doc.SagaId,
				SagaType = doc.SagaType,
				__document_id = doc.__document_id
			});
		this.ReduceDefinition = results => 
			from result in results
			group result by result.Id into g
			select new {
				g = g,
				first = DynamicEnumerable.FirstOrDefault(g)
			} into this0
			select new {
				Id = this0.g.Key,
				Uri = this0.first.Uri,
				SagaType = this0.first.SagaType
			};
		this.GroupByExtraction = result => result.Id;
		this.AddField("Id");
		this.AddField("Uri");
		this.AddField("SagaType");
		this.AddQueryParameterForMap("SagaId");
		this.AddQueryParameterForMap("SagaType");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("SagaId");
		this.AddQueryParameterForReduce("SagaType");
		this.AddQueryParameterForReduce("__document_id");
	}
}
