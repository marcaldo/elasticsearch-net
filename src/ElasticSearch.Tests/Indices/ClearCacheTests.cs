﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElasticSearch.Client;
using Nest.TestData;
using Nest.TestData.Domain;
using NUnit.Framework;
using ElasticSearch.Client.Mapping;

namespace ElasticSearch.Tests.Search
{
	[TestFixture]
	public class ClearCacheTest : BaseElasticSearchTests
	{
		[Test]
		public void test_clear_cache()
		{
			var client = this.ConnectedClient;
			var status = client.ClearCache();
			Assert.True(status.Success);
		}
		[Test]
		public void test_clear_cache_specific()
		{
			var client = this.ConnectedClient;
			var status = client.ClearCache(ClearCacheOptions.Filter | ClearCacheOptions.Bloom);
			Assert.True(status.Success);
		}
		[Test]
		public void test_clear_cache_generic_specific()
		{
			var client = this.ConnectedClient;
			var status = client.ClearCache<ElasticSearchProject>(ClearCacheOptions.Filter | ClearCacheOptions.Bloom);
			Assert.True(status.Success);
		}
		[Test]
		public void test_clear_cache_generic_specific_indices()
		{
			var client = this.ConnectedClient;
			var status = client.ClearCache(new List<string> { Settings.DefaultIndex, Settings.DefaultIndex + "_clone" }, ClearCacheOptions.Filter | ClearCacheOptions.Bloom);
			Assert.True(status.Success);
		}
	}
}