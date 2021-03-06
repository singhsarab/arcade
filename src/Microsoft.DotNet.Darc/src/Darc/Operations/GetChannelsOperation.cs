// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.DotNet.Darc.Helpers;
using Microsoft.DotNet.Darc.Options;
using Microsoft.DotNet.DarcLib;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Microsoft.DotNet.Darc.Operations
{
    internal class GetChannelsOperation : Operation
    {
        GetChannelsCommandLineOptions _options;
        public GetChannelsOperation(GetChannelsCommandLineOptions options)
            : base(options)
        {
            _options = options;
        }

        /// <summary>
        /// Retrieve information about channels
        /// </summary>
        /// <param name="options">Command line options</param>
        /// <returns>Process exit code.</returns>
        public override async Task<int> ExecuteAsync()
        {
            try
            {
                DarcSettings darcSettings = LocalSettings.GetDarcSettings(_options, Logger);
                // No need to set up a git type or PAT here.
                Remote remote = new Remote(darcSettings, Logger);

                var allChannels = await remote.GetChannelsAsync();

                // Write out a simple list of each channel's name
                foreach (var channel in allChannels)
                {
                    Console.WriteLine(channel.Name);
                }

                return Constants.SuccessCode;
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error: Failed to retrieve channels");
                return Constants.ErrorCode;
            }
        }
    }
}
