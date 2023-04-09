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

public class Transformer_MessagesBodyTransformer : Raven.Database.Linq.AbstractTransformer
{
	public Transformer_MessagesBodyTransformer()
	{
		this.ViewText = @"from message in results
select new {
	message = message,
	metadata = message.ProcessingAttempts != null ? (DynamicEnumerable.LastOrDefault(message.ProcessingAttempts)).MessageMetadata : message.MessageMetadata
} into this0
select new {
	this0 = this0,
	body = this0.message.ProcessingAttempts != null ? ((object)((DynamicEnumerable.LastOrDefault(this0.message.ProcessingAttempts)).Body ?? this0.metadata[""Body""])) : this0.metadata[""Body""]
} into this1
select new {
	MessageId = this1.this0.metadata[""MessageId""],
	Body = this1.body,
	BodySize = ((int)this1.this0.metadata[""ContentLength""]),
	ContentType = this1.this0.metadata[""ContentType""],
	BodyNotStored = ((bool)this1.this0.metadata[""BodyNotStored""])
}
";
		this.TransformResultsDefinition = results => 
			from message in ((IEnumerable<dynamic>)results)
			select new {
				message = message,
				metadata = message.ProcessingAttempts != null ? (DynamicEnumerable.LastOrDefault(message.ProcessingAttempts)).MessageMetadata : message.MessageMetadata
			} into this0
			select new {
				this0 = this0,
				body = this0.message.ProcessingAttempts != null ? ((object)(this.__dynamic_null != (DynamicEnumerable.LastOrDefault(this0.message.ProcessingAttempts)).Body ? (DynamicEnumerable.LastOrDefault(this0.message.ProcessingAttempts)).Body : this0.metadata["Body"])) : this0.metadata["Body"]
			} into this1
			select new {
				MessageId = this1.this0.metadata["MessageId"],
				Body = this1.body,
				BodySize = ((int)this1.this0.metadata["ContentLength"]),
				ContentType = this1.this0.metadata["ContentType"],
				BodyNotStored = ((bool)this1.this0.metadata["BodyNotStored"])
			};
	}
}
