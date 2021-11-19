﻿/* Copyright 2021-present MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System.Diagnostics;

namespace MongoDB.Driver.Core.TestHelpers.Logging
{
    [DebuggerStepThrough]
    internal sealed class XUnitLoggerFactory : ILoggerFactory
    {
        private readonly ILogger _loggerBase;

        public XUnitLoggerFactory(ILogger loggerBase)
        {
            _loggerBase = loggerBase;
        }

        public ILogger<TCategory> CreateLogger<TCategory>() =>
            new TypedLoggerDecorator<TCategory>(_loggerBase);
    }

    public class EmptyLoggerFactory : ILoggerFactory
    {
        public static ILoggerFactory Instance { get; } = new EmptyLoggerFactory();

        private EmptyLoggerFactory()
        {
        }

        public ILogger<TCategory> CreateLogger<TCategory>() => null;
    }
}
