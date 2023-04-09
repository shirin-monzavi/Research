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

public class Index_KnownEndpointIndex : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_KnownEndpointIndex()
	{
		this.ViewText = @"from message in docs.KnownEndpoints
select new {
	EndpointDetails_Name = message.EndpointDetails.Name,
	EndpointDetails_Host = message.EndpointDetails.Host,
	HostDisplayName = message.HostDisplayName,
	Monitored = message.Monitored,
	HasTemporaryId = message.HasTemporaryId
}";
		this.ForEntityNames.Add("KnownEndpoints");
		this.AddMapDefinition(docs => 
			from message in ((IEnumerable<dynamic>)docs)
			where string.Equals(message["@metadata"]["Raven-Entity-Name"], "KnownEndpoints", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				EndpointDetails_Name = message.EndpointDetails.Name,
				EndpointDetails_Host = message.EndpointDetails.Host,
				HostDisplayName = message.HostDisplayName,
				Monitored = message.Monitored,
				HasTemporaryId = message.HasTemporaryId,
				__document_id = message.__document_id
			});
		this.AddField("EndpointDetails_Name");
		this.AddField("EndpointDetails_Host");
		this.AddField("HostDisplayName");
		this.AddField("Monitored");
		this.AddField("HasTemporaryId");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("EndpointDetails.Name");
		this.AddQueryParameterForMap("EndpointDetails.Host");
		this.AddQueryParameterForMap("HostDisplayName");
		this.AddQueryParameterForMap("Monitored");
		this.AddQueryParameterForMap("HasTemporaryId");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("EndpointDetails.Name");
		this.AddQueryParameterForReduce("EndpointDetails.Host");
		this.AddQueryParameterForReduce("HostDisplayName");
		this.AddQueryParameterForReduce("Monitored");
		this.AddQueryParameterForReduce("HasTemporaryId");
		this.AddQueryParameterForReduce("__document_id");
	}
}
