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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace MongoDB.Driver.Core.TestHelpers.XunitExtensions.TimeoutEnforcing
{
    [DebuggerStepThrough]
    internal sealed class TimeoutEnforcingTestRunner : XunitTestRunner
    {
        public TimeoutEnforcingTestRunner(ITest test, IMessageBus messageBus, Type testClass, object[] constructorArguments, MethodInfo testMethod, object[] testMethodArguments, string skipReason, IReadOnlyList<BeforeAfterTestAttribute> beforeAfterAttributes, ExceptionAggregator aggregator, CancellationTokenSource cancellationTokenSource)
           : base(test, messageBus, testClass, constructorArguments, testMethod, testMethodArguments, skipReason, beforeAfterAttributes, aggregator, cancellationTokenSource)
        {
        }

        protected override Task<decimal> InvokeTestMethodAsync(ExceptionAggregator aggregator) =>
            new TimeoutEnforcingTestInvoker(Test, MessageBus, TestClass, ConstructorArguments, TestMethod, TestMethodArguments, BeforeAfterAttributes, aggregator, CancellationTokenSource).RunAsync();
    }
}
