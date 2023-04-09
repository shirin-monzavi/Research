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

public class Index_RetryBatches_ByStatus_ReduceInitialBatchSize : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_RetryBatches_ByStatus_ReduceInitialBatchSize()
	{
		this.ViewText = @"from doc in docs.RetryBatches
select new {
	RequestId = doc.RequestId,
	RetryType = doc.RetryType,
	HasStagingBatches = doc.Status == 2,
	HasForwardingBatches = doc.Status == 3,
	InitialBatchSize = doc.InitialBatchSize,
	Originator = doc.Originator,
	Classifier = doc.Classifier,
	StartTime = doc.StartTime,
	Last = doc.Last
}
from result in results
group result by new {
	RequestId = result.RequestId,
	RetryType = result.RetryType
} into g
select new {
	RequestId = g.Key.RequestId,
	RetryType = g.Key.RetryType,
	Originator = (DynamicEnumerable.FirstOrDefault(g)).Originator,
	HasStagingBatches = Enumerable.Any(g, x => x.HasStagingBatches),
	HasForwardingBatches = Enumerable.Any(g, x0 => x0.HasForwardingBatches),
	InitialBatchSize = Enumerable.Sum(g, x1 => ((int)x1.InitialBatchSize)),
	StartTime = (DynamicEnumerable.FirstOrDefault(g)).StartTime,
	Last = DynamicEnumerable.Max(g, x2 => ((DateTime)x2.Last)),
	Classifier = (DynamicEnumerable.FirstOrDefault(g)).Classifier
}";
		this.ForEntityNames.Add("RetryBatches");
		this.AddMapDefinition(docs => 
			from doc in ((IEnumerable<dynamic>)docs)
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "RetryBatches", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				RequestId = doc.RequestId,
				RetryType = doc.RetryType,
				HasStagingBatches = doc.Status == 2,
				HasForwardingBatches = doc.Status == 3,
				InitialBatchSize = doc.InitialBatchSize,
				Originator = doc.Originator,
				Classifier = doc.Classifier,
				StartTime = doc.StartTime,
				Last = doc.Last,
				__document_id = doc.__document_id
			});
		this.ReduceDefinition = results => 
			from result in results
			group result by new {
				RequestId = result.RequestId,
				RetryType = result.RetryType
			} into g
			select new {
				RequestId = g.Key.RequestId,
				RetryType = g.Key.RetryType,
				Originator = (DynamicEnumerable.FirstOrDefault(g)).Originator,
				HasStagingBatches = Enumerable.Any(g, (Func<dynamic, bool>)(x => x.HasStagingBatches)),
				HasForwardingBatches = Enumerable.Any(g, (Func<dynamic, bool>)(x0 => x0.HasForwardingBatches)),
				InitialBatchSize = Enumerable.Sum(g, (Func<dynamic, int>)(x1 => ((int)x1.InitialBatchSize))),
				StartTime = (DynamicEnumerable.FirstOrDefault(g)).StartTime,
				Last = DynamicEnumerable.Max(g, (Func<dynamic, DateTime>)(x2 => ((DateTime)x2.Last))),
				Classifier = (DynamicEnumerable.FirstOrDefault(g)).Classifier
			};
		this.GroupByExtraction = result => new {
			RequestId = result.RequestId,
			RetryType = result.RetryType
		};
		this.AddField("RequestId");
		this.AddField("RetryType");
		this.AddField("Originator");
		this.AddField("HasStagingBatches");
		this.AddField("HasForwardingBatches");
		this.AddField("InitialBatchSize");
		this.AddField("StartTime");
		this.AddField("Last");
		this.AddField("Classifier");
		this.AddQueryParameterForMap("RequestId");
		this.AddQueryParameterForMap("RetryType");
		this.AddQueryParameterForMap("InitialBatchSize");
		this.AddQueryParameterForMap("Originator");
		this.AddQueryParameterForMap("Classifier");
		this.AddQueryParameterForMap("StartTime");
		this.AddQueryParameterForMap("Last");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("RequestId");
		this.AddQueryParameterForReduce("RetryType");
		this.AddQueryParameterForReduce("InitialBatchSize");
		this.AddQueryParameterForReduce("Originator");
		this.AddQueryParameterForReduce("Classifier");
		this.AddQueryParameterForReduce("StartTime");
		this.AddQueryParameterForReduce("Last");
		this.AddQueryParameterForReduce("__document_id");
	}
}
