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

public class Index_SagaDetailsIndex : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_SagaDetailsIndex()
	{
		this.ViewText = @"from doc in docs.SagaSnapshots
select new {
	SagaId = doc.SagaId,
	Id = doc.SagaId,
	SagaType = doc.SagaType,
	Changes = new[] {
		new {
			Endpoint = doc.Endpoint,
			FinishTime = doc.FinishTime,
			InitiatingMessage = doc.InitiatingMessage,
			OutgoingMessages = doc.OutgoingMessages,
			StartTime = doc.StartTime,
			StateAfterChange = doc.StateAfterChange,
			Status = doc.Status
		}
	}
}
from doc in docs.SagaHistories
select new {
	SagaId = doc.SagaId,
	Id = doc.SagaId,
	SagaType = doc.SagaType,
	Changes = doc.Changes
}
from result in results
group result by result.SagaId into g
select new {
	g = g,
	first = DynamicEnumerable.FirstOrDefault(g)
} into this0
select new {
	Id = this0.first.SagaId,
	SagaId = this0.first.SagaId,
	SagaType = this0.first.SagaType,
	Changes = Enumerable.ToList(this0.g.SelectMany(x => x.Changes).OrderByDescending(x0 => x0.FinishTime))
}";
		this.ForEntityNames.Add("SagaSnapshots");
		this.AddMapDefinition(docs => 
			from doc in ((IEnumerable<dynamic>)docs)
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "SagaSnapshots", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				SagaId = doc.SagaId,
				Id = doc.SagaId,
				SagaType = doc.SagaType,
				Changes = new[] {
					new {
						Endpoint = doc.Endpoint,
						FinishTime = doc.FinishTime,
						InitiatingMessage = doc.InitiatingMessage,
						OutgoingMessages = doc.OutgoingMessages,
						StartTime = doc.StartTime,
						StateAfterChange = doc.StateAfterChange,
						Status = doc.Status
					}
				},
				__document_id = doc.__document_id
			});
		this.ForEntityNames.Add("SagaHistories");
		this.AddMapDefinition(docs => 
			from doc in ((IEnumerable<dynamic>)docs)
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "SagaHistories", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				SagaId = doc.SagaId,
				Id = doc.SagaId,
				SagaType = doc.SagaType,
				Changes = doc.Changes,
				__document_id = doc.__document_id
			});
		this.ReduceDefinition = results => 
			from result in results
			group result by result.SagaId into g
			select new {
				g = g,
				first = DynamicEnumerable.FirstOrDefault(g)
			} into this0
			select new {
				Id = this0.first.SagaId,
				SagaId = this0.first.SagaId,
				SagaType = this0.first.SagaType,
				Changes = Enumerable.ToList(this0.g.SelectMany((Func<dynamic, IEnumerable<dynamic>>)(x => (IEnumerable<dynamic>)(x.Changes))).OrderByDescending((Func<dynamic, dynamic>)(x0 => x0.FinishTime)))
			};
		this.GroupByExtraction = result => result.SagaId;
		this.AddField("Id");
		this.AddField("SagaId");
		this.AddField("SagaType");
		this.AddField("Changes");
		this.AddQueryParameterForMap("SagaId");
		this.AddQueryParameterForMap("SagaType");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForMap("Changes");
		this.AddQueryParameterForReduce("SagaId");
		this.AddQueryParameterForReduce("SagaType");
		this.AddQueryParameterForReduce("__document_id");
		this.AddQueryParameterForReduce("Changes");
	}
}
