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

public class Transformer_FailedMessages_UniqueMessageIdAndTimeOfFailures : Raven.Database.Linq.AbstractTransformer
{
	public Transformer_FailedMessages_UniqueMessageIdAndTimeOfFailures()
	{
		this.ViewText = @"from failedMessage in results
select new {
	UniqueMessageId = failedMessage.UniqueMessageId,
	LatestTimeOfFailure = DynamicEnumerable.Max(failedMessage.ProcessingAttempts, x => ((DateTime)x.FailureDetails.TimeOfFailure))
}
";
		this.TransformResultsDefinition = results => 
			from failedMessage in ((IEnumerable<dynamic>)results)
			select new {
				UniqueMessageId = failedMessage.UniqueMessageId,
				LatestTimeOfFailure = DynamicEnumerable.Max(failedMessage.ProcessingAttempts, (Func<dynamic, DateTime>)(x => ((DateTime)x.FailureDetails.TimeOfFailure)))
			};
	}
}
