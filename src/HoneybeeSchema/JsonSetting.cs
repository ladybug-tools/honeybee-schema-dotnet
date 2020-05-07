﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HoneybeeSchema
{

    public static class JsonSetting
    {
		private static JsonSerializerSettings _setting;
		public static JsonSerializerSettings AnyOfConvertSetting
		{
			get {

				if (_setting == null)
				{
					_setting = new JsonSerializerSettings
					{
						NullValueHandling = NullValueHandling.Ignore,
						//DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
						Converters = new List<JsonConverter>() { new AnyOfJsonConverter() }
					};
				}
				return _setting; 
			}
		}

	}
}