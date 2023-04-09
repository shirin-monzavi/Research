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

public class Index_ArchivedGroupsViewIndex : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_ArchivedGroupsViewIndex()
	{
		this.ViewText = @"from doc in docs.FailedMessages
where doc.Status == 4
select new {
	doc = doc,
	failureTimes = doc.ProcessingAttempts.Select(x => x.FailureDetails.TimeOfFailure)
} into this0
from failureGroup in this0.doc.FailureGroups
select new {
	Id = failureGroup.Id,
	Title = failureGroup.Title,
	Count = 1,
	First = DynamicEnumerable.Min(this0.failureTimes),
	Last = DynamicEnumerable.Max(this0.failureTimes),
	Type = failureGroup.Type
}
from result in results
group result by new {
	Id = result.Id,
	Title = result.Title,
	Type = result.Type
} into g
select new {
	Id = g.Key.Id,
	Title = g.Key.Title,
	Count = Enumerable.Sum(g, x => ((int)x.Count)),
	First = DynamicEnumerable.Min(g, x0 => ((DateTime)x0.First)),
	Last = DynamicEnumerable.Max(g, x1 => ((DateTime)x1.Last)),
	Type = g.Key.Type
}";
		this.ForEntityNames.Add("FailedMessages");
		this.AddMapDefinition(docs => 
			from doc in ((IEnumerable<dynamic>)docs)
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "FailedMessages", System.StringComparison.InvariantCultureIgnoreCase)
			where doc.Status == 4
			select new {
				doc = doc,
				failureTimes = doc.ProcessingAttempts.Select((Func<dynamic, dynamic>)(x => x.FailureDetails.TimeOfFailure)),
				__document_id = doc.__document_id
			} into this0
			from failureGroup in ((IEnumerable<dynamic>)this0.doc.FailureGroups)
			select new {
				Id = failureGroup.Id,
				Title = failureGroup.Title,
				Count = 1,
				First = DynamicEnumerable.Min(this0.failureTimes),
				Last = DynamicEnumerable.Max(this0.failureTimes),
				Type = failureGroup.Type,
				__document_id = this0.__document_id
			});
		this.ReduceDefinition = results => 
			from result in results
			group result by new {
				Id = result.Id,
				Title = result.Title,
				Type = result.Type
			} into g
			select new {
				Id = g.Key.Id,
				Title = g.Key.Title,
				Count = Enumerable.Sum(g, (Func<dynamic, int>)(x => ((int)x.Count))),
				First = DynamicEnumerable.Min(g, (Func<dynamic, DateTime>)(x0 => ((DateTime)x0.First))),
				Last = DynamicEnumerable.Max(g, (Func<dynamic, DateTime>)(x1 => ((DateTime)x1.Last))),
				Type = g.Key.Type
			};
		this.GroupByExtraction = result => new {
			Id = result.Id,
			Title = result.Title,
			Type = result.Type
		};
		this.AddField("Id");
		this.AddField("Title");
		this.AddField("Count");
		this.AddField("First");
		this.AddField("Last");
		this.AddField("Type");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForMap("Id");
		this.AddQueryParameterForMap("Title");
		this.AddQueryParameterForMap("Type");
		this.AddQueryParameterForReduce("__document_id");
		this.AddQueryParameterForReduce("Id");
		this.AddQueryParameterForReduce("Title");
		this.AddQueryParameterForReduce("Type");
	}
}
